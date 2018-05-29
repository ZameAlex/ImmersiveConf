## What is it?
This is one part of the educational project, the purpose of which was the creation of 3D Videoconferencing System ([based on a such pyramid](https://i.ytimg.com/vi/LbGvM5THvzA/maxresdefault.jpg)). This is a client application that receives an image from the server and creates its scan for display on the pyramid.

## Stack
.NET Framework 4.5.2, WPF, C#

## NuGet Dependencies
websocket-sharp by sta ([GitHub](https://github.com/sta/websocket-sharp))

## Client

### Some features

 - Does not use MVVM to improve performance.
 - Data binding is used only for the layout of the screen itself, not for display.

### Configuration

 - ServerMainImageEndpoint: Full connection string to server, e.g. ws://localhost:8888/main
 - MainImageIndex: It indicates the location on the screen of the "main" image (which is not subjected to rotations): 0 - left, 1 - top, 2 - right, 3 - bottom.
 - AspectRatio: It indicates the aspect ratio of "main" image.

### Configuration Examples

    MainImageIndex = 0, AspectRatio = 1,77777778

The "main" image is displayed on the left and has a 16:9 aspect ratio.

    MainImageIndex = 1, AspectRatio = 1,77777778

The "main" image is displayed on the top and has a 16:9 aspect ratio.

    MainImageIndex = 1, AspectRatio = 0,75

The "main" image is displayed on the top and has a 3:4 aspect ratio.