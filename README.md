CompUhaul
=============

Your file management framework (in Windows) resource.

Summary
-------

This library is meant to help developers generate file management frameworks more easily in their Windows applications, and provides (inheritable) base classes for various filesystem and component file types. Proper use also indirectly reminds developers to edit their assembly file before application release. (Auto-magic assembly naming at runtime is currently being explored.)

This library (like many others) is based almost entirely around the notion that a developer can focus on making awesome software when another (hopefully not boring) developer worries about the details for them. It only has a few methods for now, but will grow with the needs of my personal and university projects. It's also guaranteed to grow if Microsoft doesn't screw up their strategies for emerging versions of Windows - but that's another conversation altogether.

Notes
-----

All code in this library has been composed in a self-documenting fashion and styled for readability where possible. All public members, methods, and constructors have complete XML documentation for use with VS Intellisense.

This solution, including unit tests and architectural models, was created, debugged, and deployed using [Visual Studio 2012 Ultimate with MSDN](http://en.wikipedia.org/wiki/Microsoft_Visual_Studio#Visual_Studio_2012) (link contains addtional references). The solution may not open properly if you try using an earlier or less feature-saturated version of Visual Studio. If a later version is used, be sure to check the cloned solution against original source code to ensure that compatiblity changes haven't significantly altered existing functionality.

Instructions
------------

To get your machine ready for development with this repository:

1. Clone the repository to your machine.
2. Navigate to the directory you cloned your repository to.
3. Locate the Visual Studio 2012 solution file.
3. Open the solution in Visual Studio (2012 or later)

Viola! You're good to go!
