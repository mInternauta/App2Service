# App2Service
Turn any application in Windows Service  in 2 clicks

----------

## Configuration

See in the project source : Services.cfg

Name: Name of the service 

Executable: Path to the executable 

Parameters: Arguments to the application separated by space 

StopWithService:  if its true the service, the service will try to close the application by sending a signal ( WM_QUIT ) if the application does not close , there will be a KILL to force the application to quit. 

RedirectStandardOutput:  Redirect the Standard Output to the Log 

## Install
To install execute the Install.cmd and Uninstall.cmd to uninstall the service.

----------
Copyright (c) mInternauta 2015
