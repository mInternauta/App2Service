# App2Service
Turn any application in Windows Service  lin 2 clicks

----------

## Configuration

`<ArrayOfServiceSet xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">

  <ServiceSet>
    <Name>MyName</Name>
    <Executable>MyTest.exe</Executable>
    <Parameters>1 2</Parameters>
    <StopWithService>false</StopWithService>
    <RedirectStandardOutput>false</RedirectStandardOutput>
  </ServiceSet>
  
    <ServiceSet>
    <Name>MyName 2 </Name>
    <Executable>MyTest2.exe</Executable>
    <Parameters></Parameters>
    <StopWithService>true</StopWithService>
    <RedirectStandardOutput>true</RedirectStandardOutput>
  </ServiceSet>
</ArrayOfServiceSet>`

Keys
| Key | Description |
| ---- | ------------- |
| Name | Name of the service |
| Executable | Path to the executable |
| Parameters | Arguments to the application separated by space |
| StopWithService | if its true the service, the service will try to close the application by sending a signal ( WM_QUIT ) if the application does not close , there will be a KILL to force the application to quit. |
| RedirectStandardOutput | Redirect the Standard Output to the Log |

## Install
To install execute the Install.cmd and Uninstall.cmd to uninstall the service.


----------
Copyright (c) mInternauta 2015
