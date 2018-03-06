# MediaServerMonitor (AioM) All in one Monitor 
AioM is designed to alert you when a device in your home network / media center environment is not working properly. You can be alerted via Email or Push Bullet when a device goes down/non-responsive. AioM will also provide you with an all in one connection portal to manage your various web servers/smart devices. 
## Features: 
##### SMTP: 
-Alert you via EMAIL when a service state changes. 
##### Push Bullet:
-Alert you via android/ios notification when a service state changes. 
##### Plex:
-Up/Down status
-API Responsive
##### Sonarr:
-Up/Down status
-API Responsive
##### Sabnzbd:
-Up/Down status
-API Responsive
##### Radarr:
-Up/Down status
-API Responsive
##### Media Converter:
- Ability to monitor UNC path for media files, Convert to desired codec.
- Users will have the option to handle the old file in the following ways (Retain, Delete) -- Some users may perfer multiple file formats. 
- Will use FFMPEG for media conversions and support all codec's avalible in the release container that is present at time of implementation. 


## Project Status: 
- On run if database is missing latest features/tables they will be created/updated to latest version.  
- Users can add services to SQLiteDB instance. 
- Users can delete services from SQLiteDB. 
- Foundation to edit services is availible -- However not functional. 

Monitoring of services: 
- Database tables are created pending insertions for statae changes. 

