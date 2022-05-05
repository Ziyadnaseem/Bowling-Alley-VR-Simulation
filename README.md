## Bowling Alley VR Simulation Application

### Instructions to run VR app on Oculus Quest

1. Make sure Android build support module is installed with Unity  
https://developer.oculus.com/documentation/unity/book-unity-gsg/#install-unityeditor

2. Settings:  
i. If you are using OpenXR for development then go to Window -> "Package manager" -> Go to "Unity registry" tab -> install "XR interaction toolkit" & "XR plugin management"  
ii. Edit -> "Project settings" -> "XR plugin management" -> In android tab, select Oculus  
iii. File -> "Build Settings" -> "Select Android platform" -> Build (this should output an APK build) (you may require to click "Switch Platform" button if asked).  

3. Make sure you have ADB installed. Checkout this link for help  
``https://www.xdadevelopers.com/install-adb-windows-macos-linux/``  

4. Use a Typa-A to Type-C cable (typical type-c cable) to connect Oculus to machine.  
``Run adb install <path/apk-name>``
