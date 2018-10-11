# 3d_projection_mapping_unity
3D projection mapping for CityScope mobility exhibition in Cooper Hewitt design museum in New York City Dec 2018. 


# Video Tutorials

## Projection Calibration Tutorial

To be updated...
  
  
# Updates

## Oct 4th, 2018
* Imported mesh model simplified from Lego Builder 3D model done by Maitana Iruretagoyena.  
* Applied icon textures to building rooftops. Icon illustrated by Maitana Iruretagoyena and Guadalupe Babio.  
<img src="https://github.com/popabczhang/3d_projection_mapping_unity/blob/master/doc/181004_building%20mesh%20model%20with%20icons.png" width="600">
  
* Constructed the table top according to Carson Smuts's drawings.  
<img src="https://github.com/popabczhang/3d_projection_mapping_unity/blob/master/doc/181004_table%20model.png" width="600">

## Oct 5th, 2018
* Tested first 3D projection mapping on test table (CityMatrix) with only camera position but no box morph(3D keystone). It was a great success: 3D geometry and physical Lego building perfectly matched.  
![](https://github.com/popabczhang/3d_projection_mapping_unity/blob/master/doc/181005_3d-projection-by-positioning-camera.gif)

## Oct 6th, 2018
* Programmed the mesh box morph (3D Keystone) for 3D projection mapping detailed calibration. A user can control 8 key points of a bounding box to morph/twist the mesh geometry proportionally. This is a technical milestone for the success of the exhibition. The math behind is vector bilinear interpolation ([ref link](https://forum.unity.com/threads/vector-bilinear-interpolation-of-a-square-grid.205644/)). Pure C# code by Ryan Yan Zhang, no Unity Assets needed.  
![](https://github.com/popabczhang/3d_projection_mapping_unity/blob/master/doc/181006_mesh%20box%20morph%20test.gif)

## Oct 7th, 2018
* Added a quick test script for slider scanning via webcam, working great: When the red pen passing the slider detecting area, the black detecting points turn white, and the slider value on the right updates correctly. Note that the background is quite complex: with strong contract of bright and dark, as well as my hand, which is similar as red, but it can still catagorize red without a problem.  
This test is conducted according to the discussion with Carson Smuts. It could be an alternative/backup plan for scanners in other software, such as Python, JS or Processing. The advantage of doing it in Unity is performance and stability as a result of software integrity (considering that the 3D projection mapping will be done in Unity).  
![](https://github.com/popabczhang/3d_projection_mapping_unity/blob/master/doc/181007_slider-scanning-test.gif)

## Oct 8th, 2018
* Applied 8 point box morph on CityMatrix test table and the result is very promising. 
<img src="https://github.com/popabczhang/3d_projection_mapping_unity/blob/master/doc/181008_box%20morph%20on%20citymatrix.jpg" width="1000">

## Oct 10th, 2018
* Added animated texture for roof top. MP4 is needed as source file.  
![](https://github.com/popabczhang/3d_projection_mapping_unity/blob/master/doc/181010_anim-texture.gif)  
Animation in the image above is from Maitana Iruretagoyena.  
* The animated texture works very well with box-morph script.  
![](https://github.com/popabczhang/3d_projection_mapping_unity/blob/master/doc/181010_box-morph-anim.gif)  
* Box-morph script updated so that it automatically clone the origianl parent gameobject that you would like to morph and morph the cloned one. It diactivate the origianl gameobject automatically. 
* Update the table top drawing mesh from quad to plan(10x10 grid) so that the box morph can work correctly. Quad has to few vertices, when morph, the distortion is not smooth. 
