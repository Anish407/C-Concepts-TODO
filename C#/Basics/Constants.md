## Constants as local variables
<img width="1011" alt="image" src="https://github.com/Anish407/C-Concepts/assets/51234038/a4abf0f6-a5be-4504-915f-fb59b0cb2c88">

if we look at the pic above we can see that a local variable is assigned some memory(based on the type value/reference type). But if we change the local variabale
to a constant then it gets <i> inlined </i> directly

<img width="1044" alt="image" src="https://github.com/Anish407/C-Concepts/assets/51234038/e560cb72-1b3d-4db4-98ea-18ac7575c71e">

## Constants from outside the scope

<img width="1033" alt="image" src="https://github.com/Anish407/C-Concepts/assets/51234038/1f7bd6e5-5722-4daa-9313-8dbd6a32527f">

## Constants when added with a parameter
![image](https://github.com/Anish407/C-Concepts/assets/51234038/6bca944f-9ee5-491b-83ba-be4713a87e37)

## Constants used in another class also get INLINED
![image](https://github.com/Anish407/C-Concepts/assets/51234038/492e8067-eb03-4c8c-8ad5-0f986173faea)


## Points to Rememeber
- A constant expression is an expression that can be fully evaluated at compile time. 
- constants are implicitly static
