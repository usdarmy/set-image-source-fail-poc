# Set image source fail POC

The application loads images from disk and displays them using binding between the view model property and the Source property of the Image element.
Clicking within the application loads a different image. After repeated clicking (sometimes after a minute or longer, please keep clicking),
the window remains white - the image does not display. If this was implemented in a more complex application (with multiple Pages and navigation between them),
the error occurred earlier. In the debugger, the loading looks okay, and the Live Property Explorer shows everything as if it were loaded correctly.git

## Updated - Commands
Edited according to the response on [Stack Overflow](https://stackoverflow.com/a/78009922/21235130)

The bug no longer seems to be manifesting. However, there is an annoying white flash when replacing the image.