# First-Person-Virtual-Reality-Platformer-Game-for-Android-Unity3D
![Level 1: Isometric Viewport Perspective](https://i.ibb.co/qMxSJt8/platformer-pic-1.png)
A colorful, minimalist first-person platformer game.
Uses phone's gyroscope for augmented-reality immersion: using a phone mount/headset, turn your head in the real
                                                        world to rotate the view in-game
Implements Google VR SDK for Unity3D.

----------------------------------------------------------------------------------------------------------------------------------------

# FINAL MILESTONE:
Making the platformer more presentable- using Unity’s Standard Assets

For this next step, I wanted to go back and flesh out some aspects of my platformer application/game, and to make the game have a more simplistic look. I imported Unity’s Standard Assets and used platform prefabs from the Prototyping folder and applied Box Colliders to them to make my new platforms, which look a lot neater than the ones I added textures to. With wall prefabs from the same assets that I imported, I created a simple level with a walled off area for the player to start the game at and platforms that I added my horizontal and vertical moving scripts to. I also added a cartoon-styled skybox, which is a sky background for the game environment. The skybox I used is one of several free skybox assets found on the Unity Asset Store.

### Player movement script: auto-walking and position reset

#### 1. Auto-walking

![Forward condition](https://i.ibb.co/NyWjtkq/player-looking-right.png)
![Idle condition](https://i.ibb.co/0MPdJvp/player-should-not-move.png)

After setting up my environment, I proceeded to make new player movement scripts using parts of what I wrote for my last milestone to better suit the VR platformer game I wanted to make. For this game, I settled for having player controls limited to the player moving their head/phone; due to time constraints, using a controller to control movements such as walking and jumping would have to be set aside because I did not have enough time to learn how to create a working UDP or TCP communication with the application (which would run the server program) and controller (which would run a client program that sends packets of information in TCP to the server) over wifi or other mediums.

I wanted to make my player walk in whatever direction they are looking at, except when looking too high or too low. For walking forward, I recycled code from my old movement script. Then I added public float variables that govern the minimum and maximum x rotation the main camera can be at that would allow for the player to move forward, and then if statements that would check the condition. Checking the condition actually turned out more tricky than I thought it would be, because the rotation values shown in the camera’s Inspector when testing my script are not shown as the values are stored in the code; the camera’s rotation is stored as a float equal to a hundredth of the value shown in the Inspector. Thus, when I wrote:

if(Camera.main.transform.rotation.x >= minXBounds  &&
Camera.main.transform.rotation.x <= maxXBounds)

I struggled for a while because I did not understand why my player would not stop moving when looking at an angle greater than my float maxXBounds. After using Debug.Log() to print debug lines to Unity’s console that told me what my main camera’s x rotation was during the game, I figured out that a simple fix was to just check for values in relation on minXBounds * 0.01 and maxXBounds * 0.01.

My auto-walking script can be found on GoogleDrive here: auto-walk script

#### 2. Resetting player position when player is out of bounds

After I got this to work, I wanted to make game testing easier, so I needed a script that resets the player to the starting area when the player GameObject falls too far below the platforms (so I can test run the level without restarting the game). I found how to accomplish this in sluice’s answer at: saving and loading player positions. This also taught me that I can store float values and tag them with a string using PlayerPrefs.SetFloat(). The strings are used to refer to the variable I want to access with PlayerPrefs.GetFloat() later.

Picture of player GameObject in Unity 3D used to show how it should move when the camera is not looking too high or too low.
Player object in game made on Unity3D should not move when the camera is looking at too low or too high.
Porting my game to my phone as an .apk

With my basic game working, I was ready to build my Unity project as an Android application to my phone. To do so, I followed the official Unity guide available here: building to Android. However, I ran into several problems along the way. After I downloaded the Android command line tools, I was unable to run the android.bat executable file successfully; when I ran it, the command prompt window that should appear showed up but then closed itself quickly. I tried to run the file as administrator, then attempted to use Talha’s solution on StackOverflow. However, my android.bat still could not locate java in my file directory. I ended up downloading the full Android Studio, which includes the command lines. With this, I was able to direct Unity 3D to the location of the Android SDK (command lines) that was included in the Android Studio installation. The last hiccup outside of the Unity guide that I encountered was that for my project, I had to set the minimum Android version for my application to be Kitkat, as GoogleVR is only useable on Android versions of at least Kitkator higher. Once this was dealt with and the appropriate prerequisites for running the VR app were installed on my phone (automatically), I was finally able to see my project working on my phone!

----------------------------------------------------------------------------------------------------------------------------------------

# HALFWAY MARK:

After following and completing Matthew Hallberg’s Instructables project, I went on to create my first augmented-reality Unity3D game.

### Documentation below, including useful terms/concepts for beginners:

GameObjects are components in the game environment such as a plane for ground, and the player itself. These do not only encompass objects visible to the player, as Empty objects can be made. Scripts, or programs (C# or Java script in Unity) can be attached to these to make the object manage functions such as ending the game when the player messes up. A scene is the workspace that objects can be placed in, and serves as a “level” in many games because the scene in play can be switched to allow a player to progress from one stage to another. The Camera object provides perspectives that the player can see the game through; first person games would have the main camera object within the player’s character and facing the direction the player object’s eyes would be facing.

#### Setting up the Unity project for a Virtual Reality supported Android build

Since I aimed to make a virtual reality game for Android, I learned that I should import the Google Virtual Reality Software Development Kit (GVR SDK) for Unity v1.60, which I downloaded here: GVR sdk download. The GoogleVR SDK is a Software Development Kit, or a bundle of  software tools used for the development of applications, directed at Virtual Reality applications. This SDK comes in a package that has prefabs, or already made GameObjects, that are free to use. The prefabs in this package have scripts attached to them that accomplish tasks such as making a camera object rotate using a phone’s sensors as an input.

After importing the package, I opened up the demo projects within the package to see if I could figure out how the prefabs worked by looking at how the projects were put together. Since multiple prefabs were used in the demos, I wanted to know which ones were the minimum needed to tie camera rotation to phone rotation, as that is all that I will need for my first VR game. After doing some research, I found out that I could not follow almost any guide on using prefabs from GVR SDK because a new version for the SDK had been released. To check the version and changes, I visited Google VR SDK release notes. Many of the prefabs people were using before had been deprecated, or removed, and replaced with new assets that accomplish the same function but in different ways. I found it difficult to find recent tutorials, but eventually found one on Youtube which takes a look at the demos on a version closer to the one I was using (v1.50) and how to set up the Unity project to build to Android: NurFace Games’ v1.50 release overview.

To set up the Unity project for Android, I navigated to File > Build Settings from the top tool bar of Unity and selected Android as my application’s platform and clicked Switch Platform. Then, to set it up for VR, I clicked on the Player Settings button next to “Switch Platform” and checked Virtual Reality Supported under Other Settings in the Player Settings tab that appears in the Inspector window. Then an area with the text “Virtual Reality SDKs will appear below it. Clicking the “+” symbol in this area will allow you to select from several SDKs; I selected Google Cardboard for this project.

#### Making a Move-able Player (Keyboard and Arduino NodeMCU control)

Moving on, I wanted to create a first person platformer as my first application. From NurfaceGame’s video (the one linked above), I learned that the GVREditorEmulator is the prefab used for creating the first person view with mobile input (rotation with phone movement). Adding a Camera object to the GVREditorEmulator in the inspector sets that Camera as the one that will rotate when the phone rotates. I then made a capsule GameObject as a simple player model and made a Camera (which I tagged as MainCamera) and the GVREditorEmulator as Child objects because they are components of the player. To assign the camera perspective that the GVREditorEmulator will use, I chose my MainCamera in the Camera input area in the GVREditorEmulator’s Inspector.

Making the player moveable with WASD and arrow key movement was my next goal. First, I made the plane in my game environment have a box collider so that the player would not fall through it. Then I wrote a simple script that changed the position of the character object by changing transform.position.x for the x-axis value, and so on if a certain button is down. This script was applied directly to the player object to make button presses change the player object’s position, not another object’s. I tested my code by putting my player on a textured plane so I could see if the player was moving relative to the ground. I found that the player object would tip over because it was a capsule object, so I froze its x, y, and z position and rotation in its Inspector- movement caused by a script changing the position of the object will still work.

Making the jumping script was similar to the walking script, making the player translate up on the y axis when the space bar is pressed with a short cooldown. However, since the jumping motion was updated every frame, my player jumped up extremely quickly. Furthermore, when the player landed on the plane, it tilted and flew away, which prompted me to lock its x, y, and z positions/rotations in its Inspector tab.

#### Establishing a Serial Communication between my NodeMCU and Unity 3D and making walking dependent on Camera orientation

After I successfully finished with these scripts, I wanted to make my NodeMCU controller control walking forward and jumping. I found a sample script that would allow me to send String to Unity from my NodeMCU through a serial communication in Farneze’s answer here: Arduino to Unity serial coms. I then added if statements to my walking code that made the player’s x position increase when my SerialPort object read a string equal to “walk” and added the same functionality to my jumping script. This ended up working, but I realized that I wanted the player to move in the direction he/she is facing, because they may not be facing the increasing side of the x axis. I found the right direction for writing my script in GargerathSunman’s answer on the Unity forums: Moving in direction camera is facing. I ended up changing the code to depend on a walkSpeed variable rather than my Time setting on Unity.

After implementing that logic, I found that when my player looked up and walked, they would “walk” up. Since I didn’t want this, I saved the player object’s y position as a float before moving and set the y position back to that after moving.

![ViewPort old level](https://i.ibb.co/gMCt2jg/unity-workspace-1-1024x544.png)

#### Adding moving platforms

The last thing I finished for this milestone is making several platforms that the player can jump over for a possible parkour simulator. For my horizontal and vertical movement looping scripts that I used for my platforms, I used KellyThomas’ script found here: platform movement loop.

#### Player movement script (C#) on Google Drive:

movement script with serial communication (reading) with Arduino
