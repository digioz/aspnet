Welcome to DigiOz Simple Chat Version 1.0.

This web application is a simple ASP.NET / Microsoft SQL Chat Application. 

Installation:
-------------
1. Create a blank database called "digiozsimplechat". 

2. Open the "web.config" file, and fine the "connectionStrings" section. Replace 
   "myusername" and "mypass" with the Username and Password to your newly created database.
   
3. Open the "schema" folder, and run the following SQL files in your Databases Query Window in 
   the following order:

	i.   tblUsers.sql
	ii.  tblUsersOnline.sql
	iii. tblMessages.sql
	iv.  InsertChatMessage.sql
	v.   UpdateUsersOnline.sql

4. Upload the chatroom files onto your server and run Default.aspx. 

Enjoy!
Pete Soheil
DigiOz Multimedia
www.digioz.com