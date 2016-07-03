# Explanation: #

You are given the beginning of the line that's needed (My.ArcMap.Application.). The use of the preset global variable My.ArcMap.Application should tell you that the property needed will be listed under the IApplication interface. It is then up to you to look over the list of properties in either the Developer Help or the OMD for the correct property. The Name property may seem logical, but this is a read-only property (as shown by the lack of a square on the right side of the barbell). It turns out that the Name property is meant to be used to determine whether your program is being executed in ArcMap or ArcCatalog.

The correct property is Caption. The presence of squares on both sides of the barbell indicates that it is a read-write property. The property is changed by using the basic object.property = newvalue syntax.
