# Wiring-Management-System
An app to help manage data center wiring.

## To Run:
1. Go to the Releases page, and download WiringManagementSystem.zip
2. Extract the .zip file to a location of your choosing
3. Run the WiringManagementSystem application file
-  Note: The application might be named WiringManagementSystem.exe on some systems

## User Manual:
### Main Menu:
The tree view lists all devices and racks in the database.
Click the [+] icon next to a rack/device to see all of its child devices

### Add Device:
1. Select a rack to add the new device to
2. If the device is in a Pod, select the appropriate Pod
3. Select the type of device you are adding
-  Note: If the device type is set to Pod, the application will not allow you to add the device to a Pod
4. Click "Add"

### Edit Device:
1. Select a device
2. Click the "Edit Device" button
3. When you are done editing a device, click "Edit"

### Delete Device:
1. Select a device you want to delete
2. A confirmation pop-up will ask if you are sure you want to delete the device
-  Note: If the device has child devices, deleting the device will also delete the child devices

### Refresh:
Forces the application to get data from the database and update the tree view

### Saving Notes:
Type anything into the "Notes" text box, then click "Save Notes"
