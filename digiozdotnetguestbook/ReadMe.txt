DigiOz .NET Guestbook Version 1.1

The Digioz .NET Guestbook is a Guestbook System written in ASP.NET 2.0, which uses Serialization to store messages as serialized XML text files. It supports multiple languages and smiley faces, as well as an administrative interface to remove unwanted messages.

Installation:
-------------

1. Copy the "digiozdotnetguestbook" folder to your Web Server, naming it whatever you like (such as "guestbook"). 
2. Give the IIS "IUSER_MachineName" Read/Write/Execute Permission to "App_Data" Folder, in order for the Application to be able to write Guestbook Entries to it as XML files. 
3. Open web.config file, and edit the AdminUsername and AdminPassword keys to whatever you wish your guestbook administrator's login to be. 
4. Save "web.config", and navigate to the directory lister URL in the format http://www.[Your Domain Name.com]/[Path To Guestbook]/Default.aspx.

