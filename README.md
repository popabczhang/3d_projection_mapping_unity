# 3d_projection_mapping_unity
3D projection mapping for CityScope mobility exhibition in Cooper Hewitt design museum in New York City Dec 2018.  
  
  
# Projection Calibration Tutorial
For 1st Time On-Site Setup and Calibration:  
  
	1. Download the release v1.0.0 "CityScope_Cooper_Hewitt_Top_Projection_Unity_V1.0.0.app.zip" from github.com/popabczhang/3d_projection_mapping_unity, unzip and put the app on the desktop of the 4K projector display;  
    
	2. Set up batch script accordingly (please ask Yasushi);  
    
	3. Run "CityScope_Cooper_Hewitt_Top_Projection_Unity_V1.0.0.app" on desktop;  
    
	4. In the popup Unity display setup window, select resolution "3840*2160"(4K), select quality "very low", check "show this window only when hold alt", and hit "run";  
    
	5. Press "u" on the keyboard to toggle on the calibration UI (there's a reminder message for this at very beginning, which will close in 5 sec);  
    
	6. Make sure that "Use UDP" is checked to receive UDP from good computer python scanner;  
    
	7. 3D camera to physical projector calibration (although we have 3D bounding box morphing calibration later, to reduce discrepancy between the linear morph and the perspective principle, we would like to match the 3D camera in Unity to the physical projector rather well, but go too crazy about it though):  

		a. Firstly, to start, in the "Camera Input" menu (the menu with dark background), refer to the diagram, measure the physical dimensions of the projector portion and rotation, and input the parameters of the camera position and rotation accordingly (note that we would like to set up the projector as orthogonal as possible to reduce the necessity for have rotations);  
    
		b. Then, in the lower part of main UI menu (the menu with light gray background), there are a set of buttons for more fine-grained calibration of position, rotation, and field of view angle of the 3D camera:  

			1) Button explanations: "": move camera left, right, up and down (the image will move in the opposite direction; "": angle;  
      
	8. When the image is more or less match with the physical table, save the camera setting by click "Save" button in the "Cam" session of the main UI menu;  
  
	9. Now we can start the fine-grained calibration by morph or keystone the geometry, check "Calibrate" at the top left of the main menu to show calibration key points on following objects:  
  
		a. All buildings: because buildings are three dimensional, we need to do 3D box-morphing with 8 key points. The 8 key points are marked magenta and labeled with 0~7 in order (if you stand at the slider side of the table, 0:lower-closer-left; 1:lower-closer-right; 2:lower-farther-right; 3:lower-farther-left; 4:higher-closer-left; 5:higher-closer-right; 6:higher-farther-right; 7:higher-farther-left); Drag each of the key points using mouse to have it match the 8 corners in physical world (use the calibration Lego piece Guadalupe made for the precis height and position of the corners);  
      
		b. Left and right side videos: these are 2D objects at height of table top, so there are only 4 key points marked yellow;  
      
		c. Slider: 4 orange key points that #0 should be at closer-left corner of the road; #1 should be at the closer-right corner of the road; #2 should be at the perpendicular point from #1 to bottom edge of the table; #3 should be at the perpendicular point from #1 to bottom edge of the table. 
  
  
(to be continued ... ) 
  
  
  
  
  
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

## Oct 12th, 2018
* Cooper-Hewitt test table in MIT Media Lab calibrated  
* Gabi's good bad world building top anims  
* Added World A B Filter effect via shader  
  * white seperation edge for world filter via shader  
  
![](https://github.com/popabczhang/3d_projection_mapping_unity/blob/master/doc/181012_world-filter-gabi-anim.gif)  
