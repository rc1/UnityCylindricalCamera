# Cylindrical Camera Example for Unity 3D

A 360 degree cylindrical panorama capture using Unity 3D.

![cylindrical camera 2](https://cloud.githubusercontent.com/assets/166915/15828438/36637fe4-2c07-11e6-92a4-d86daba7a8ed.gif)

The 360 degree view is rendered to a single render texture. The pixel dimensions of the render texture can be changed as the four camera used to capture the scene will auto reconfigure themselves to match the dimension. A shader can then be applied to the render texture, which will unwraps the scene so it has near no distortion.
