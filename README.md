# GE21-22-Assignment

Name: Johann-Dorian Gudenus

Student Number: C19518983

Class Group: Game Design

# Description of the project

The idea for this project is to create a representation of a vaporwave style of audio visualisation. This will include RGB, neon textures, and a procedural terrain, as well as a number of different songs. In addition there will be bright particles to fill the screen to ensure that the project doesnt feel too empty.

[Watch the Project](https://youtu.be/EgTOUdCkO38)

Visual Aspects

- Frequency-line responding to the music along the horizon
- Particles, to please the eye
- a bobbing effect, given by the terrain


Interactive Aspects

- A button/key to change song
- Buttons and sliders to interact with the visuals

# Instructions for use

- Use mouse to drag sliders, and to use toggles and dropdown bar

# How it works

- The terrain is procedurally generated using Perlin Noise, with an offset, to give a "random seed" every time it is launched. Furthermore this offset gets moved, in order to give the false image of movement, across the floor.
```
// create values to use for math further on in the script
    public int depth = 4;
    public int width = 256;
    public int length = 256;
    public float scale = 20f;
    public float xOffset = 100f;
    public float yOffset = 100f;
    public static float speed = 2.5f;


    void Start()
    {
        xOffset = Random.Range(0f, 9999f);                         //offsets in order to randomize the map when launching and adding a movement effect
        yOffset = Random.Range(0f, 9999f);
    }

    void Update()
    {

        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData); //taking value form the below terrain data that is being generated and passing into the current terrain

        yOffset += Time.deltaTime * speed;                          //adding the "movement effect" of the project

        
    }

    TerrainData GenerateTerrain(TerrainData terrainData)
    {
        terrainData.heightmapResolution = width * 1;                //adjusting the terrains heightmap to the be in order with the rest of the map
        terrainData.size = new Vector3(width, depth, length);       //setting terrain size
        terrainData.SetHeights(0, 0, GenerateHeights());            //setting terrain height values -- with a bew function that generats these height values
        return terrainData;                                         //returning terraindata values
    }

    float[,] GenerateHeights()                                      //using a float array, to fill the previous setHeights argument
    {
        float[,] heights = new float[width, length];                
        for (int x = 0; x< width; x++)
        {
            for(int y = 0; y < length; y++)                         //nested for loop that cycles through the maps length and width
            {
                heights[x, y] = CalculateHeight(x, y);              //setting each coordinate and using a new float to calculate those positions
            }
        }

        return heights;                                             //return heights value
    }

    float CalculateHeight(int x, int y)                             //new float to calculate each coordinate
    {
        float xCoordinate = (float)x / width * scale + xOffset;     //calculating x & y for each coordinate, making them float values
        float yCoordiante = (float)y / length * scale + yOffset;

        return Mathf.PerlinNoise(xCoordinate, yCoordiante);         //using perlin noise for pseudo-random generation
    }

    public void Scaling (float newScale)
    {
        scale = newScale;                                           //setting terrain scale to match the slidebar value
    }

    public void SpeedChange (float newSpeed)
    {
        speed = newSpeed;                                           //setting terrain speed to math slidebar value
    }
```

- The cube instanciater works by calculating position, rotation and direction of cubes, and then instanciating them by passing them through a for loop which increases the distance between the cubes so as to have them spawn where needed. It then uses FFT values to change the cubes´ scaling.
```
// create values to further on in the script

    public GameObject sun;
    public GameObject sacrificialcube;
    GameObject[] cubes = new GameObject[128];
    public float maxScaling;
    public float radius = 3.14f;

    void Start()
    {
        for (int i = 0; i < 128; i++)                                                                                   //for loop that will instanciate the cubes for the audio visualiser
        {
            Quaternion rotate = Quaternion.AngleAxis((-2.8125f * i) + 90, Vector3.right);                               //setting the rotation angle at which the cubes will be instanciated appart from each other
            Vector3 direction = rotate * Vector3.up;                                                                    //setting the direction in which the cubes will be instanciated
            Vector3 position = (direction * radius) + sun.transform.position;                                           //setting the position at which the cubes will be instanciated


            GameObject instanceCube = (GameObject)Instantiate(sacrificialcube, position, rotate);                       //command to actually instanciate the cubes
            instanceCube.transform.parent = this.transform;                                                             //setting all the instanciated cubes as children of a single object
            
            instanceCube.name = "sacrificialcube" + i;                                                                  //naming the instanciated cubes
            cubes[i] = instanceCube;                                                                                    //setting the for value to be equal to the ube value, so the right amount gets instanciated
        }
    }

    void Update()
    {
        for (int i = 0; i < 128; i++)                                                                                   //for loop that changes the cube scaling individually
        {
            if (cubes != null)
            {
                
                cubes[i].transform.localScale = new Vector3( 10, audioScript.audioBlocks[i] * maxScaling + 2, 10 );     //setting the cube scale, to be equal to a value from the audioScript that fetches FFT values
            }
        }
    }
     public void scaling(float scaling)
    {
        maxScaling = 500 * scaling;                                                                                     //public function that allows the slidebar to affect the scaling
    }
```

-The audio script listens to the audio and fetches FFT values, which then get fed into the cubes in order to change their scaling.

```
    AudioListener audioListener;
    public static float[] audioBlocks = new float[128];                                                 //array that will hold FFT values
 

    void Start()
    {
        audioListener = GetComponent<AudioListener>();                                                  //making the audioListener be able to listen to the audio
    }


    void Update()
    {
        AudioListener.GetSpectrumData(audioBlocks, 0, FFTWindow.Hamming);                               //telling the audio listener to fetch frequency values, and feed them into the audioBlocks array
    }
```

- The multiscource script allows for a selection between songs using the dropdown bar in the UI.
```

    public AudioSource audioSource;                                                             
    public AudioClip Song1, Song2, Song3, Song4, Song5, Song6;                                  //public song pool




    void Start()
    {
        audioSource.GetComponent<AudioSource>();                                                //making the audiosource be able to play the songs that the script will determine
    }

    public void HandleInputData(int TrackNumber)                                                // public function to allow the dropdown bar to select a tracknumber
    {
        if (TrackNumber == 0)                                                                   //each tracknumber represents a different song. Track number 0 holds a "--Please Select--" field
        {
            audioSource.Stop();
           
        }
        if (TrackNumber == 1)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(Song1);
        }
        if (TrackNumber == 2)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(Song2);
        }
        if (TrackNumber == 3)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(Song3);
        }
        if (TrackNumber == 4)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(Song4);
        }
        if (TrackNumber == 5)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(Song5);
        }
        if (TrackNumber == 6)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(Song6);
        }

    }

    public void pauseButton()
    {
        audioSource.Pause();                                                    //telling the script to pause the song that is being played when pressing the pause button
    }

    public void resumeButton()
    {
        audioSource.UnPause();                                                  //--^-- in relation to resuming the music
    }

```

- The Black sun script toggles dark mode on or off for the sun
```

    //declaring materials to switch then when swapping colour modes

    public Material normalSun;
    public Material BlackSun;
    public MeshRenderer myMR;


   
    void Start()
    {
        myMR = GetComponent<MeshRenderer>();                                    //making the meshRenderer actually grab the respective component
    }

    public void SunChange(bool BSM)                                             //public function to make it accessible by the toggle button
    {
        if (BSM == true)                                                        //if statement, saying that if the toggle is turned on, then show off dark mode, otherwise show the normal colourmode
        {
            myMR.material = BlackSun;
        }
        else
        {
            myMR.material = normalSun;
        }
    }
```

- The black terrain script changes the material for the floor
```
    //declaring materials to switch then when swapping colour modes

    public Terrain terrain;
    public Material normalFloor;
    public Material BlackFloor;

    void Start()
    {
        terrain = GetComponent<Terrain>();                                          //making the meshRenderer actually grab the respective component
    }

    public void FloorChange(bool DFM)                                               //public function to make it accessible by the toggle button
    {
        if (DFM == true)                                                            //if statement, saying that if the toggle is turned on, then show off dark mode, otherwise show the normal colourmode
        {
            terrain.materialTemplate = BlackFloor;
        }
        else
        {
            terrain.materialTemplate = normalFloor;
        }
    }
```

- The RGB script changes the HSV values on a single material. It changes the H value by cycling through a loop, and updates the entire time. It also uses the UI toggle to swap to a white material which is used in dark mode. It also relates to terrain offset speed.
```
    //declaring materials to switch then when swapping colour modes

    public Material normalColour;
    public Material BrightColour;
    public static MeshRenderer myMR;
    public static bool BSM;
    private float colorval;


    
    void Start()
    {
        myMR = GetComponentInChildren<MeshRenderer>();                                  //making the meshRenderer in each childed cube actually grab the respective component
    }

    void Update()
    {
        normalColour.color = Color.HSVToRGB(colorval, 1, 1);                            //setting a HSV value, to cycle through colour, since only the H value has to be changed, making cycling easier
        colorval += Time.deltaTime * terrainGeneration.speed * 0.5f;                    //setting the colourvalue to change with time, as well as the speed at which the terrain is going (times 0.5 for a better feel

        if (colorval >= 1)                                                              //setting the H value to loop all the floats from 0-1
        {
            colorval = 0;
        }

        if (BSM == true)
        {
            myMR = GetComponentInChildren<MeshRenderer>();                              //grabbing the meshRenderer in each child again to set it to a white colour if to toggle buttong for dark mode is set to true
            myMR.material = BrightColour;
        }
        else
        {
            myMR = GetComponentInChildren<MeshRenderer>();                              //making sure the material on the instanciated cubes actually gets updated along with the H value that the material is holding
            myMR.material = normalColour;
        }
    }

    public void ColourChange()
    {
        BSM = !BSM;                                                                     //setting a swap for the dark mode toggle
    }

```

- The terrainFollow script adds the bobbing effect in combination with the lookAt script
```
    void Update()
    {
        Vector3 myPos = transform.position;                  //grabbing the curent vector3 of the camera

        myPos.y = Terrain.activeTerrain.SampleHeight(myPos); // grabbing the height of the terrain under the camera
        myPos.y += 4;                                        // adding onto the terrain height

        transform.position = myPos;                          // changing camera height to be updated to the new value
    }
```
```
    public Transform target;

    void Update()
    {
        transform.LookAt(target);               //setting the camera to look at a public target(the sun)
    }
```

- The particle script changes the particle speed to be in relation to the speed slidebar, which also refers to the speed at which the colour cycles through the cubes, as well as the speed the terrain moves at
```
    public ParticleSystem topLeft, topRight, Middle;
    private float speed = 10f;

    
    void Update()
    {
        topLeft.startSpeed = speed;                 //setting the particle speed equal to a custom value
        topRight.startSpeed = speed;
        Middle.startSpeed = speed;
    }

    public void speedchange(float newSpeed)         //public function to handle particle speed
    {
        speed = speed * newSpeed;                   //setting the speed to be affected by the slidebar speed, that also handles rgb speed and terrain speed
        if (speed >= 20)
        {
            speed = 20f;
        }
    }
```

# List of classes/assets with sources

| Class | Source |
|-----------|-----------|
| BlackSunMode.cs | Self written |
| BlackTerrainMode.cs | Self written |
| Cubeinstantiater.cs | Modified from [Source](https://www.youtube.com/watch?v=Ri1uNPNlaVs) |
| MeshGeneratorSCript.cs | taken from [Source](https://www.youtube.com/watch?v=64NblGkAabk) |
| RGB.cs | Self written |
| audioScript.cs | Self written |
| lookAt.cs | Self written |
| multisource.cs | Self written |
| particles.cs | Self written |
| terrainGeneration.cs | taken from [Source](https://www.youtube.com/watch?v=vFvwyu_ZKfU) |
| terrainFollow.cs | Self written |


| Asset | Source |
|-----------|-----------|
| Floor texture | Taken from [Source](https://answers.unity.com/questions/1761928/how-to-make-nice-neon-grid.html) |
| SkyBox | Taken from [Source](https://tools.wwwtyro.net/space-3d/index.html) |




# References
[Cubeinstantiater.cs](https://www.youtube.com/watch?v=Ri1uNPNlaVs)

[MeshGeneratorSCript.cs](https://www.youtube.com/watch?v=64NblGkAabk)

[terrainGenerator.cs](https://www.youtube.com/watch?v=vFvwyu_ZKfU)

[Floor texture](https://answers.unity.com/questions/1761928/how-to-make-nice-neon-grid.html)

[SkyBox](https://tools.wwwtyro.net/space-3d/index.html)

# What I am most proud of in the assignment

I am really proud of how mesmerising I managed to get this project to be. I really felt that this is what the brief asked for. Something that wows the viewer when watching, something that can be relaxing, or exciting. The colours blend incredibly well, and give off exactly the efffect I wanted them too.
