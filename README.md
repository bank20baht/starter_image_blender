# starter_image_blender 240-441 MULTI-CORE PRO & ARCHITECTURE
blender program using c# destop app

#หลักการทำงานของโปรเเกรม
โปรแกรมจะสร้าง bitmap อันใหม่ขึ้นมาซึ่งมีขนาดเท่ากับ image1 เพื่อไว้เป็นผลลัพท์จากการ blending จากนั้นการ blending จะเป็นแบบ alpha blending ก็คือ 
  
- result =  alpha*image1 + (100 – alpha)*image2

ซึ่งจากสมการนี้ทำโดยการใช้ loop แล้วให้แต่ละบิทของ result เป็นไปตามสมการข้างต้นจากนั้นก็ unlockbit แล้วก็แสดงค่าออกทาง imagebox โดยค่า alpha ที่ใช้จะได้มาจาก treakBar ที่อยู่ในโปรแกรม หากมีการเลื่อน treakBar ก็จะมีการ blending ภาพโดยอัตโนมัติ แต่ก็มีปุ่มสำหรับการ blend ไว้อยู่เช่นกัน

กดปุ่ม load image
![Screenshot 2023-03-24 191058](https://user-images.githubusercontent.com/89448778/227518085-e10da454-dd3c-4e1d-b493-8d5417256b74.png)

#การทำงานสามารถดำเนินการได้ 2 เเบบคือ
- กดปุ่ม blend image ก็จะเอาค่าจะ track bar ปัจจุบันมาเป็นสัดส่วนในการทำ
![Screenshot 2023-03-24 190233](https://user-images.githubusercontent.com/89448778/227518322-0863e6c4-bb70-43f8-9118-6fc521b3d9d0.png)

- เลื่อน trackbar เอง ผลลัพท์ที่ได้ก็จะขยับไปตามค่าที่ได้จาก track bar เเล้วเเสดงผลที่หน้าโปรเเกรม
ซ้ายสุด
![Screenshot 2023-03-24 190334](https://user-images.githubusercontent.com/89448778/227518703-0352f9ea-6a8f-48f2-b69c-c81886189589.png)

ขวาสุด
![Screenshot 2023-03-24 190348](https://user-images.githubusercontent.com/89448778/227518773-4f328b44-f6bd-4bb9-889f-6eb3b3e31748.png)

ค่อนไปทางขวา
![Screenshot 2023-03-24 190406](https://user-images.githubusercontent.com/89448778/227518809-74139e4a-e245-468f-b2d2-897155cb3d04.png)
