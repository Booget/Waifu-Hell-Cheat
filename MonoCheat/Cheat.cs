using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Object = UnityEngine.Object;

using UnityEngine;

namespace MonoCheat
{
    internal class Cheat : MonoBehaviour
    {
        public static Rect Window = new Rect(10, 10, 400, 200);

        // Cheat toggles
        public static bool toggleGodmode { get; set; }
        public static bool unlimitedAmmo { get; set; }
        public static bool superSpeed { get; set; }
        public static bool superJump { get; set; }
        public static bool gravityChanger { get; set; }
        public static bool fovValToggle { get; set; }
        public static bool toggleHeightChanger { get; set; }
        public static bool toggleBhop { get; set; }
        public static bool toggleAirstrafe { get; set; }

        static float speedVal = 7f;
        static float jumpHeight = 8f;
        static float gravityVal = 20f;
        static float fovVal = 90f;
        static float yHeightVal = 0.6f;
        static float airStrafeVal = 0.3f;

        public void Start()
        {   

        }

        public void Update()
        {
            // Loop for Godmode
            if (toggleGodmode) 
            {
                Object.FindObjectOfType<PlayerHealth>().currentHealth = 125;
            }

            // Loop for unlimited ammo
            if (unlimitedAmmo)
            {
                Object.FindObjectOfType<TrailerBullets>().startAmmo = 100;
            }

            // Loop for super speed
            if (superSpeed)
            {
                Object.FindObjectOfType<CPMPlayer>().moveSpeed = speedVal;
            }
            else if (!superSpeed)
            {
                Object.FindObjectOfType<CPMPlayer>().moveSpeed = 7f;
            }

            // Loop for super jump
            if (superJump)
            {
                Object.FindObjectOfType<CPMPlayer>().jumpSpeed = jumpHeight;
            }
            else if (!superJump)
            {
                Object.FindObjectOfType<CPMPlayer>().jumpSpeed = 8f;
            }

            // Loop for gravity changer
            if (gravityChanger)
            {
                Object.FindObjectOfType<CPMPlayer>().gravity = gravityVal;
            }
            else if (!gravityChanger)
            {
                Object.FindObjectOfType<CPMPlayer>().gravity = 20f;
            }
            
            // Loop for gravity changer
            if (fovValToggle)
            {
                Object.FindObjectOfType<Camera>().fieldOfView = fovVal;
            }
            else if (!fovValToggle)
            {
                Object.FindObjectOfType<Camera>().fieldOfView = 90f;
            }

            // Loop for height changer
            if (toggleHeightChanger)
            {
                Object.FindObjectOfType<CPMPlayer>().playerViewYOffset = yHeightVal;
            }
            else if (!toggleHeightChanger)
            {
                Object.FindObjectOfType<CPMPlayer>().playerViewYOffset = 0.6f;
            }

            // Loop for bhop
            if (toggleBhop)
            {
                Object.FindObjectOfType<CPMPlayer>().holdJumpToBhop = true;
            }
            else if (!toggleBhop)
            {
                Object.FindObjectOfType<CPMPlayer>().holdJumpToBhop = false;
            }

            // Loop for air controll
            if (toggleAirstrafe)
            {
                Object.FindObjectOfType<CPMPlayer>().airControl = airStrafeVal;
            }
            else if (!toggleAirstrafe)
            {
                Object.FindObjectOfType<CPMPlayer>().airControl = 0.3f;
            }

        }
        public void LateUpdate()
        {   

        }

        public void OnGUI()
        {
            Window = GUILayout.Window(0, Window, (GUI.WindowFunction)WindowContent, "HentaiKilla", new GUILayoutOption[0]);
        }
        
        public void WindowContent(int id)
        {
            // Godmode toggle
            if (GUILayout.Toggle(toggleGodmode, "Godmode", new GUILayoutOption[0]) != toggleGodmode)
            {
                toggleGodmode = !toggleGodmode;
            }

            // Unlimited ammo toggle
            if (GUILayout.Toggle(unlimitedAmmo, "Unlimited Ammo", new GUILayoutOption[0]) != unlimitedAmmo)
            {
                unlimitedAmmo = !unlimitedAmmo;
            }
            if (GUILayout.Toggle(toggleBhop, "Bhop", new GUILayoutOption[0]) != toggleBhop)
            {
                toggleBhop = !toggleBhop;
            }

            // Air controll toggle
            if (GUILayout.Toggle(toggleAirstrafe, $"Air Controll [{airStrafeVal}]", new GUILayoutOption[0]) != toggleAirstrafe)
            {
                toggleAirstrafe = !toggleAirstrafe;
            }
            airStrafeVal = GUILayout.HorizontalSlider(airStrafeVal, 0f, 5f);

            // Super speed toggle & slider
            if (GUILayout.Toggle(superSpeed, $"Super Speed [{speedVal}]", new GUILayoutOption[0]) != superSpeed)
            {
                superSpeed = !superSpeed;
            }
            speedVal = GUILayout.HorizontalSlider(speedVal, 1.0f, 120.0f);

            // Super jump toggle & slider
            if (GUILayout.Toggle(superJump, $"Jump Height [{jumpHeight}]", new GUILayoutOption[0]) != superJump)
            {
                superJump = !superJump;
            }
            jumpHeight = GUILayout.HorizontalSlider(jumpHeight, 1.0f, 120.0f);

            // Gravity speed toggle & slider
            if (GUILayout.Toggle(gravityChanger, $"Gravity Changer [{gravityVal}]", new GUILayoutOption[0]) != gravityChanger)
            {
                gravityChanger = !gravityChanger;
            }
            gravityVal = GUILayout.HorizontalSlider(gravityVal, 1.0f, 30.0f);

            // FOV toggle & slider
            if (GUILayout.Toggle(fovValToggle, $"FOV Changer [{fovVal}]", new GUILayoutOption[0]) != fovValToggle)
            {
                fovValToggle = !fovValToggle;
            }
            fovVal = GUILayout.HorizontalSlider(fovVal, 1.0f, 200f);

            // Gravity speed toggle & slider
            if (GUILayout.Toggle(toggleHeightChanger, $"Height Changer [{yHeightVal}]", new GUILayoutOption[0]) != toggleHeightChanger)
            {
                toggleHeightChanger = !toggleHeightChanger;
            }
            yHeightVal = GUILayout.HorizontalSlider(yHeightVal, 0.0f, 20.0f);

            if (GUILayout.Button("Take Damage (-10)"))
            {
                Object.FindObjectOfType<PlayerHealth>().TakeDamage(10);

            }

            if (GUILayout.Button("Kill Player"))
            {
                Object.FindObjectOfType<PlayerHealth>().TakeDamage(100);
            }

            if (GUILayout.Button("Add score to leaderboards (999999999)"))
            {
                Object.FindObjectOfType<Leaderboard>().AddScore(999999999);
            }


            GUI.DragWindow();
        }

        public void FixedUpdate()
        {

        }
    }
}
