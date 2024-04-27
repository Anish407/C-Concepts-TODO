## Static Methods and How CLR works with them
In .NET, static methods, like other methods, are stored in the metadata of the assembly that contains them. Here’s a breakdown of how this storage and referencing happen:

- Method Definitions and Metadata:
Static methods are defined within a class, and the method definitions are stored in the metadata of the .NET assembly. The metadata includes information about the method's name, its accessibility (e.g., public, private), parameters, return type, and any attributes or modifiers (like static).
This metadata is stored in a tabular format as part of the assembly's metadata tables. These tables are essential for the Common Language Runtime (CLR) to understand and execute the code correctly.
- Intermediate Language (IL) Code:
The actual code of static methods is compiled into Intermediate Language (IL). IL is a CPU-independent set of instructions that can be executed by the .NET runtime. This IL code is stored within the assembly’s file, linked to the method definition via metadata.
When a static method is called, the CLR looks up the method metadata, finds the corresponding IL, and just-in-time (JIT) compiles it into native machine code specific to the hardware it’s running on.
- Memory Allocation During Execution:
When the .NET application starts, static members (including static methods) of a class are initialized. Unlike instance methods, static methods do not require an instance of the class to be invoked.
Static methods are not stored per instance; they are part of the type’s definition. Therefore, the memory overhead for static methods is less compared to instance methods as there is only a single copy of each static method, regardless of how many instances of the class exist.
- Just-In-Time Compilation:
The first time a static method is called, its IL is compiled into native code by the JIT compiler. This compiled native code is then stored in a dynamically allocated memory segment known as the "code cache" or "JIT cache."
Subsequent calls to the static method use the already compiled native code from the code cache, speeding up execution.
- Method Dispatch:
The dispatch of a static method call is straightforward compared to instance methods since it does not involve dynamic dispatch (like virtual calls). The CLR can directly reference the JIT-compiled code in memory after the initial JIT compilation.
In summary, static methods in .NET are stored as metadata and IL within the assembly, and they are JIT-compiled into native code at runtime, which is then stored in the code cache for efficient execution. This approach optimizes performance and memory usage for applications running on the .NET framework.

## Non Static Methods and Dynamic Dispatch (virtual methods)
In .NET, non-static methods, or instance methods, are invoked on instances of classes and the process can involve dynamic dispatch if the method is virtual.

### Method Calling Process
When a non-static method is called, the following steps are generally involved:

1. Instance Reference: To call a non-static method, there needs to be an instance of the class. This instance contains the non-static fields of the object and a reference to the method table (often part of what is known as the object's "vtable" or virtual method table).
2. Method Table: Each class in .NET has a method table. This table is essentially a list of pointers to methods that can be called on an instance of the class. For non-virtual methods, the pointer directs straight to the method's implementation.
3. Execution: The runtime uses the instance's method table to find the address of the method's implementation in memory. If the method is non-virtual, this process is straightforward: the method table contains a direct pointer to the method, which is then executed.

### Dynamic Dispatch and Virtual Methods
Dynamic dispatch is used when calling virtual methods. This allows .NET to support polymorphism, where a method call on an object can invoke different method implementations depending on the object's actual derived type at runtime. Here’s how dynamic dispatch works:

1. Virtual Method Table (VTable): When a class has virtual methods, its method table includes pointers not necessarily to the methods declared in the class itself, but potentially to overridden methods in derived classes. Each class and derived class has its own version of the method table, pointing to the most specific implementation of each method that the class provides.
2. Determination at Runtime: When you call a virtual method on an object, the CLR looks at the actual type of the object at runtime to determine which method table to use. It then uses the pointer in this table to call the appropriate method. This lookup happens every time a virtual method is called, which is why it's termed "dynamic."

```
public class Animal {
    public virtual void Speak() {
        Console.WriteLine("Some generic sound");
    }
}

public class Dog : Animal {
    public override void Speak() {
        Console.WriteLine("Bark");
    }
}

Animal myAnimal = new Dog();
myAnimal.Speak(); // Outputs: Bark

```
In this example, even though myAnimal is declared as type Animal, it points to an instance of Dog. The method Speak() is virtual and overridden in Dog, so the dynamic dispatch ensures that Dog.Speak() is called.

3. 3. Performance Considerations
Dynamic dispatch adds a small overhead due to the runtime type check and the indirect method call through the method table. However, this overhead is generally quite small and is the price for the flexibility and power of polymorphism in object-oriented programming.

In summary, non-static methods in .NET are called through a direct lookup in the method table for non-virtual methods or through a dynamic dispatch mechanism for virtual methods, which involves looking up the most specific implementation of a method at runtime based on the actual object type. This system enables polymorphism, allowing different behaviors in derived classes without changing the way methods are called.
