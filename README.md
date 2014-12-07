ReloadSignal
============

Just a simple live reload using signalr.
Build and run in a command prompt with administrator permissions:

```
ReloadSignal\bin\Debug>ReloadSignal.exe c:\projects\reloadsignal\ClientApplication
```

It will watch the directory ClientApplication for any changes, in any subdirectories.
It will setup a server at port 4000, on all ips on the machine.

Insert the script tag on your client that you want to reload.

``` html
<script src="http://localhost:4000/scripts/client.js"></script> 
```
