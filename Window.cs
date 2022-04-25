using System.Collections.Generic;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Windowing.Desktop;
using System;
using OpenTK.Mathematics;
using LearnOpenTK.Common;
using System.Drawing;

namespace ConsoleApp3
{
    static class Constants
    {
        public const string path = "../../../Shaders/";
    }
    class Window : GameWindow
    {
        List<Asset3d> objectList = new List<Asset3d>();

        // utk animasi terbang
        float a = 0;
        float b = 0;

        Camera _camera;

        bool _firstMove = true;
        Vector2 _lastPos;
        Vector3 _objectPos = new Vector3(0, 0, 0);
        float _rotationSpeed = 1f;

        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
        {

        }

        protected override void OnLoad()
        {
            base.OnLoad();

            // background
            GL.ClearColor(1f, 1f, 1f, 0f);
            GL.Enable(EnableCap.DepthTest);

            _camera = new Camera(new Vector3(0, 0, 5), Size.X / Size.Y);

            /*var land = new Asset3d(new Vector3(0.5f, 0.5f, 0f));
            land.createCuboid_v2(0f, -4f, 0f, 5f, -10f);
            objectList.Add(land);*/

            #region Kecoak
            var cockroach = new Asset3d(new Vector3(1, 1, 1));

            var angin = new Asset3d(new Vector3(0, 0, 0));
            angin.prepareVertices();
            angin.setControlCoordinate(-2.4f, -0.2f, -0.65f);
            angin.setControlCoordinate(-2.7f, -0.3f, -0.55f);
            angin.setControlCoordinate(-2.73f, -0.255f, -0.4f);
            angin.setControlCoordinate(-2.78f, -0.35f, -0.4f);
            angin.setControlCoordinate(-2.80f, -0.28f, -0.3f);
            angin.setControlCoordinate(-3.98f, -0.24f, -0.175f);
            List<Vector3> angin_bezier = angin.createCurveBazier();
            angin.setVertices(angin_bezier);
            angin.translate(4.2f, 0.25f, -2.2f);
            cockroach.child.Add(angin);

            // KAKI 1
            var cube1 = new Asset3d(new Vector3(0.5f, 0.5f, 0.5f));
            cube1.createCuboid_v2(0f, 0f, 0f, 0.1f, 1.5f);
            cube1.rotate(Vector3.Zero, Vector3.UnitX, -45);
            cube1.translate(0f, 0f, .5f);
            var cube2 = new Asset3d(new Vector3(1.5f, 0.5f, 0.5f));
            cube2.createCuboid_v2(0f, 0f, 0.75f, 0.1f, 1.5f);
            cube2.rotate(Vector3.Zero, Vector3.UnitX, 45);
            cube2.translate(0f, 0f, .5f);

            var cube7 = new Asset3d(new Vector3(0.5f, 0.5f, 0.5f));
            cube7.createCuboid_v2(0f, 0f, 0f, 0.1f, 1.5f);
            cube7.rotate(Vector3.Zero, Vector3.UnitX, 45);
            cube7.translate(0f, 0f, -1.5f);
            var cube8 = new Asset3d(new Vector3(1.5f, 0.5f, 0.5f));
            cube8.createCuboid_v2(0f, 0f, -0.75f, 0.1f, 1.5f);
            cube8.rotate(Vector3.Zero, Vector3.UnitX, -45);
            cube8.translate(0f, 0f, -1.5f);

            // KAKI 2
            var cube3 = new Asset3d(new Vector3(0.5f, 0.5f, 0.5f));
            cube3.createCuboid_v2(1.5f, 0f, 0f, 0.1f, 1.5f);
            cube3.rotate(Vector3.Zero, Vector3.UnitX, -45);
            var cube4 = new Asset3d(new Vector3(1.5f, 0.5f, 0.5f));
            cube4.createCuboid_v2(1.5f, 0f, 0.75f, 0.1f, 1.5f);
            cube4.rotate(Vector3.Zero, Vector3.UnitX, 45);

            var cube9 = new Asset3d(new Vector3(0.5f, 0.5f, 0.5f));
            cube9.createCuboid_v2(1.5f, 0f, 0f, 0.1f, 1.5f);
            cube9.rotate(Vector3.Zero, Vector3.UnitX, 45);
            cube9.translate(0f, 0f, -1f);
            var cube10 = new Asset3d(new Vector3(1.5f, 0.5f, 0.5f));
            cube10.createCuboid_v2(1.5f, 0f, -0.75f, 0.1f, 1.5f);
            cube10.rotate(Vector3.Zero, Vector3.UnitX, -45);
            cube10.translate(0f, 0f, -1f);

            // KAKI 3
            var cube5 = new Asset3d(new Vector3(0.5f, 0.5f, 0.5f));
            cube5.createCuboid_v2(-1.5f, 0f, 0f, 0.1f, 1.5f);
            cube5.rotate(Vector3.Zero, Vector3.UnitX, -45);
            var cube6 = new Asset3d(new Vector3(1.5f, 0.5f, 0.5f));
            cube6.createCuboid_v2(-1.5f, 0f, 0.75f, 0.1f, 1.5f);
            cube6.rotate(Vector3.Zero, Vector3.UnitX, 45);

            var cube11 = new Asset3d(new Vector3(0.5f, 0.5f, 0.5f));
            cube11.createCuboid_v2(-1.5f, 0f, 0f, 0.1f, 1.5f);
            cube11.rotate(Vector3.Zero, Vector3.UnitX, 45);
            cube11.translate(0f, 0f, -1f);
            var cube12 = new Asset3d(new Vector3(1.5f, 0.5f, 0.5f));
            cube12.createCuboid_v2(-1.5f, 0f, -0.75f, 0.1f, 1.5f);
            cube12.rotate(Vector3.Zero, Vector3.UnitX, -45);
            cube12.translate(0f, 0f, -1f);

            // BADAN
            var ellips1 = new Asset3d(new Vector3(0.6f, 0.4f, 0.2f));
            ellips1.createEllipsoid(0f, 0f, -0.5f, 1.75f, .5f, 1f, 50, 50);

            // KEPALA
            var ellips2 = new Asset3d(new Vector3(0.39f, 0.26f, 0.12f));
            ellips2.createEllipsoid(1.75f, -0.15f, -0.5f, .15f, .5f, .25f, 50, 50);

            var wings = new Asset3d(new Vector3(0.1f, 1f, 1f));
            wings.createHyper(-0.5f, 0f, 0f, 0.5f, 0.25f, 0.5f, 5, 100);
            wings.rotate(Vector3.Zero, Vector3.UnitY, -90);
            wings.rotate(Vector3.Zero, Vector3.UnitZ, -45);
            cockroach.child.Add(wings);

            var wings2 = new Asset3d(new Vector3(0.1f, 1f, 1f));
            wings2.createHyper(-0.5f, 0f, 0f, 0.5f, 0.25f, 0.5f, 5, 100);
            wings2.rotate(Vector3.Zero, Vector3.UnitY, -90);
            wings2.rotate(Vector3.Zero, Vector3.UnitZ, -45);
            cockroach.child.Add(wings2);

            var angin2 = new Asset3d(new Vector3(0, 0, 0));
            angin2.prepareVertices();
            angin2.setControlCoordinate(-2.4f, -0.2f, -0.65f);
            angin2.setControlCoordinate(-2.7f, -0.3f, -0.55f);
            angin2.setControlCoordinate(-2.73f, -0.255f, -0.4f);
            angin2.setControlCoordinate(-2.78f, -0.35f, -0.4f);
            angin2.setControlCoordinate(-2.80f, -0.28f, -0.3f);
            angin2.setControlCoordinate(-3.98f, -0.24f, -0.175f);
            List<Vector3> angin_bezier2 = angin2.createCurveBazier();
            angin2.setVertices(angin_bezier2);
            angin2.translate(4.2f, 0.25f, 2.2f);
            cockroach.child.Add(angin2);

            cockroach.child.Add(cube1);
            cockroach.child.Add(cube2);
            cockroach.child.Add(cube3);
            cockroach.child.Add(cube4);
            cockroach.child.Add(cube5);
            cockroach.child.Add(cube6);
            cockroach.child.Add(cube7);
            cockroach.child.Add(cube8);
            cockroach.child.Add(cube9);
            cockroach.child.Add(cube10);
            cockroach.child.Add(cube11);
            cockroach.child.Add(cube12);
            cockroach.child.Add(ellips1);
            cockroach.child.Add(ellips2);
            objectList.Add(cockroach);

            cockroach.rotate(Vector3.Zero, Vector3.UnitY, -75);
            #endregion

            #region Ant
            var ant = new Asset3d(new Vector3(3, 1, 1));

            // KAKI 1 ANT
            var cube101 = new Asset3d(new Vector3(0.78f, 0.22f, 0.22f)); // Right Upper Leg
            cube101.createCuboid_v2(1.0f, 5.25f, -1.85f, 0.1f, 2f);
            cube101.rotate(Vector3.Zero, Vector3.UnitX, -75);
            cube101.translate(0f, 0f, 0.25f);
            var cube102 = new Asset3d(new Vector3(0.78f, 0.22f, 0.22f)); // Right Lower Leg
            cube102.createCuboid_v2(1.0f, 1.3f, -4.25f, 0.1f, 3.5f);
            cube102.rotate(Vector3.Zero, Vector3.UnitX, -25);
            cube102.translate(0f, 0f, 0f);

            var cube107 = new Asset3d(new Vector3(0.78f, 0.22f, 0.22f)); // Left Upper Leg
            cube107.createCuboid_v2(1.0f, -4.75f, 1.5f, 0.1f, 2f);
            cube107.rotate(Vector3.Zero, Vector3.UnitX, 75);
            cube107.translate(0f, 2.25f, -1.5f);
            var cube108 = new Asset3d(new Vector3(0.78f, 0.22f, 0.22f));
            cube108.createCuboid_v2(1.0f, -3.375f, -5.75f, 0.1f, 3.5f); // Left Lower Leg
            cube108.rotate(Vector3.Zero, Vector3.UnitX, 25);
            cube108.translate(0f, 0f, 0f);

            // KAKI 2 ANT
            var cube103 = new Asset3d(new Vector3(0.78f, 0.22f, 0.22f)); // Right Upper Leg
            cube103.createCuboid_v2(1.5f, 5.25f, -1.85f, 0.1f, 2f);
            cube103.rotate(Vector3.Zero, Vector3.UnitX, -75);
            cube103.translate(0f, 0f, 0.25f);

            var cube104 = new Asset3d(new Vector3(0.78f, 0.22f, 0.22f)); // Right Lower Leg
            cube104.createCuboid_v2(1.5f, 1.3f, -4.25f, 0.1f, 3.5f);
            cube104.rotate(Vector3.Zero, Vector3.UnitX, -25);
            cube104.translate(0f, 0f, 0f);


            var cube109 = new Asset3d(new Vector3(0.78f, 0.22f, 0.22f)); // Left Upper Leg
            cube109.createCuboid_v2(1.5f, -4.75f, 1.5f, 0.1f, 2f);
            cube109.rotate(Vector3.Zero, Vector3.UnitX, 75);
            cube109.translate(0f, 2.25f, -1.5f);

            var cube110 = new Asset3d(new Vector3(0.78f, 0.22f, 0.22f));
            cube110.createCuboid_v2(1.5f, -3.375f, -5.75f, 0.1f, 3.5f); // Left Lower Leg
            cube110.rotate(Vector3.Zero, Vector3.UnitX, 25);
            cube110.translate(0f, 0f, 0f);

            // KAKI 3 ANT
            var cube105 = new Asset3d(new Vector3(0.78f, 0.22f, 0.22f)); // Right Upper Leg
            cube105.createCuboid_v2(2.0f, 5.25f, -1.85f, 0.1f, 2f);
            cube105.rotate(Vector3.Zero, Vector3.UnitX, -75);
            cube105.translate(0f, 0f, 0.25f);

            var cube106 = new Asset3d(new Vector3(0.78f, 0.22f, 0.22f)); // Right Lower Leg
            cube106.createCuboid_v2(2.0f, 1.3f, -4.25f, 0.1f, 3.5f);
            cube106.rotate(Vector3.Zero, Vector3.UnitX, -25);
            cube106.translate(0f, 0f, 0f);


            var cube111 = new Asset3d(new Vector3(0.78f, 0.22f, 0.22f)); // Left Upper Leg
            cube111.createCuboid_v2(2.0f, -4.75f, 1.5f, 0.1f, 2f);
            cube111.rotate(Vector3.Zero, Vector3.UnitX, 75);
            cube111.translate(0f, 2.25f, -1.5f);

            var cube112 = new Asset3d(new Vector3(0.78f, 0.22f, 0.22f));
            cube112.createCuboid_v2(2.0f, -3.375f, -5.75f, 0.1f, 3.5f); // Left Lower Leg
            cube112.rotate(Vector3.Zero, Vector3.UnitX, 25);
            cube112.translate(0f, 0f, 0f);

            // BADAN ANT
            var ellips101 = new Asset3d(new Vector3(.64f, .16f, .16f));// Gaster
            ellips101.createEllipsoid(0f, -0.1f, -5.5f, .75f, .75f, .75f, 72, 24);

            var ellips102 = new Asset3d(new Vector3(.64f, .16f, .16f));// Gaster
            ellips102.createEllipsoid(-0.5f, -0.125f, -5.5f, .75f, .75f, .75f, 72, 24);

            var ellips103 = new Asset3d(new Vector3(.64f, .16f, .16f));// Gaster
            ellips103.createEllipsoid(-1.0f, -0.25f, -5.5f, .75f, .75f, .75f, 72, 24);

            var ellips104 = new Asset3d(new Vector3(.64f, .16f, .16f));// Thorax
            ellips104.createEllipsoid(1.5f, 0f, -5.5f, 1.25f, .5f, .5f, 72, 24);

            // Kepala ANT
            var ellips105 = new Asset3d(new Vector3(.64f, .16f, .16f));// Head
            ellips105.createEllipsoid(3.0f, 0f, -5.5f, .5f, .375f, .5f, 72, 24);

            var ellips106 = new Asset3d(new Vector3(1, 0, 1));// Right Eye
            ellips106.createEllipsoid(3.25f, .25f, -5.25f, .125f, .125f, .125f, 72, 24);

            var ellips107 = new Asset3d(new Vector3(1, 0, 1));// Left Eye
            ellips107.createEllipsoid(3.25f, .25f, -5.75f, .125f, .125f, .125f, 72, 24);

            // Stinger ANT
            var wings101 = new Asset3d(new Vector3(0.1f, 1f, 1f));
            wings101.createHyper(5.5f, -5.25f, -2.5f, 0.5f, 0.1f, 0.1f, 10, 10);
            wings101.rotate(Vector3.Zero, Vector3.UnitY, 90);
            wings101.rotate(Vector3.Zero, Vector3.UnitZ, -45);

            // Antena ANT
            var cube151 = new Asset3d(new Vector3(0.78f, 0.22f, 0.22f)); // Right Antenna
            cube151.createCuboid_v2(3.0f, -0.375f, -5.125f, 0.1f, 1.5f);
            cube151.rotate(Vector3.Zero, Vector3.UnitX, 15);

            var cube152 = new Asset3d(new Vector3(0.78f, 0.22f, 0.22f)); // Left Antenna
            cube152.createCuboid_v2(3.0f, 2.5f, -5.5f, 0.1f, 1.5f);
            cube152.rotate(Vector3.Zero, Vector3.UnitX, -15);

            var torus101 = new Asset3d(new Vector3(0.88f, 0.22f, 0.22f)); // Right Antenna Torus
            torus101.createTorus(3.0625f, -5.125f, 0.375f, 0.09f, -0.05f, 100, 100);
            torus101.rotate(Vector3.Zero, Vector3.UnitX, 105);

            var torus102 = new Asset3d(new Vector3(0.88f, 0.22f, 0.22f)); // Left Antenna Torus
            torus102.createTorus(3.0625f, 5.5f, 2.5f, 0.09f, -0.05f, 100, 100);
            torus102.rotate(Vector3.Zero, Vector3.UnitX, -105);

            var torus103 = new Asset3d(new Vector3(0f, 0f, 1f)); // Mouth
            torus103.createTorusV2(3.5f, 0f, 5.65f, 0.1f, -0.05f, 100, 100);
            torus103.rotate(Vector3.Zero, Vector3.UnitX, -180);

            var torus104 = new Asset3d(new Vector3(0f, 0f, 1f)); // Mouth
            torus104.createTorusV2(3.5f, 0f, -5.45f, 0.1f, -0.05f, 100, 100);

            ant.child.Add(cube101);
            ant.child.Add(cube102);
            ant.child.Add(cube103);
            ant.child.Add(cube104);
            ant.child.Add(cube105);
            ant.child.Add(cube106);
            ant.child.Add(cube107);
            ant.child.Add(cube108);
            ant.child.Add(cube109);
            ant.child.Add(cube110);
            ant.child.Add(cube111);
            ant.child.Add(cube112);
            ant.child.Add(ellips101);
            ant.child.Add(ellips102);
            ant.child.Add(ellips103);
            ant.child.Add(ellips104);
            ant.child.Add(ellips105);
            ant.child.Add(ellips106);
            ant.child.Add(ellips107);
            ant.child.Add(cube151);
            ant.child.Add(cube152);
            ant.child.Add(torus101);
            ant.child.Add(torus102);
            ant.child.Add(torus103);
            ant.child.Add(torus104);
            objectList.Add(ant);
            #endregion

            #region Ulat
            var ulat = new Asset3d(new Vector3(1, 1, 1));
            //badan
            var badan1 = new Asset3d(new Vector3(0.0f, 0.5f, 0.1f));
            badan1.createEllipsoid(-4f, 0.0f, 1.6f, 1f, 1f, 1f, 30, 24);
            /*badan1.rotate(Vector3.Zero, Vector3.UnitX, -45);
            badan1.translate(0f, 0f, .5f);*/
            var badan2 = new Asset3d(new Vector3(0.0f, 0.5f, 0.1f));
            badan2.createEllipsoid(-4f, 0.0f, 0.8f, 1f, 1f, 1f, 30, 24);
            /*badan2.rotate(Vector3.Zero, Vector3.UnitX, -45);
            badan2.translate(0f, 0f, .5f);*/
            var badan3 = new Asset3d(new Vector3(0.0f, 0.5f, 0.1f));
            badan3.createEllipsoid(-4f, 0.0f, 0.0f, 1f, 1f, 1f, 30, 24);

            var badan4 = new Asset3d(new Vector3(0.5f, 1.5f, 0.5f));
            badan4.createEllipsoid(-4f, 0.8f, 2.6f, 1f, 1f, 1f, 30, 24);

            /*badan2.rotate(Vector3.Zero, Vector3.UnitX, -45);
            badan2.translate(0f, 0f, .5f);*/

            //kaca mata
            var mata1 = new Asset3d(new Vector3(0.5f, 1.5f, 1.5f));
            mata1.createTorus(-4.3f, 3.6f, -1f, 0.3f, 0.1f, 100, 100);
            mata1.rotate(Vector3.Zero, Vector3.UnitX, 90);
            var mata2 = new Asset3d(new Vector3(0.5f, 1.5f, 1.5f));
            mata2.createTorus(-3.7f, 3.6f, -1f, 0.3f, 0.1f, 100, 100);
            mata2.rotate(Vector3.Zero, Vector3.UnitX, 90);
            var gagangpanjang1 = new Asset3d(new Vector3(0.0f, 0.0f, 0.0f));
            gagangpanjang1.createCuboid_v2(-5f, 3.63f, -1f, 0.1f, 2f);
            gagangpanjang1.rotate(Vector3.Zero, Vector3.UnitX, 90);
            var gagangpanjang2 = new Asset3d(new Vector3(0.0f, 0.0f, 0.0f));
            gagangpanjang2.createCuboid_v2(-3f, 3.63f, -1f, 0.1f, 2f);
            gagangpanjang2.rotate(Vector3.Zero, Vector3.UnitX, 90);

            var gagangkecil1 = new Asset3d(new Vector3(0.0f, 0.0f, 0.0f));
            gagangkecil1.createCuboid_v3(-4.8f, 1f, 3.6f, 0.2f);
            var gagangkecil2 = new Asset3d(new Vector3(0.0f, 0.0f, 0.0f));
            gagangkecil2.createCuboid_v3(-3.2f, 1f, 3.6f, 0.2f);
            //gagangkecil1.rotate(Vector3.Zero, Vector3.UnitX,360);
            //kaki
            var kaki1 = new Asset3d(new Vector3(0.0f, 0.8f, 0.3f));
            kaki1.createEllipsoid(-4.5f, -1f, 0f, 0.2f, 0.5f, 0.2f, 10, 20);
            kaki1.rotate(Vector3.Zero, Vector3.UnitX, 45);
            var kaki2 = new Asset3d(new Vector3(0.0f, 0.8f, 0.3f));
            kaki2.createEllipsoid(-3.5f, -1f, 0f, 0.2f, 0.5f, 0.2f, 10, 20);
            kaki2.rotate(Vector3.Zero, Vector3.UnitX, 45);
            var kaki3 = new Asset3d(new Vector3(0.0f, 0.8f, 0.3f));
            kaki3.createEllipsoid(-4.5f, -1f, 0.5f, 0.2f, 0.5f, 0.2f, 10, 20);
            kaki3.rotate(Vector3.Zero, Vector3.UnitX, 40);
            var kaki4 = new Asset3d(new Vector3(0.0f, 0.8f, 0.3f));
            kaki4.createEllipsoid(-3.5f, -1f, 0.5f, 0.2f, 0.5f, 0.2f, 10, 20);
            kaki4.rotate(Vector3.Zero, Vector3.UnitX, 40);
            var kaki5 = new Asset3d(new Vector3(0.0f, 0.8f, 0.3f));
            kaki5.createEllipsoid(-4.5f, -0.5f, 1f, 0.2f, 0.5f, 0.2f, 10, 20);
            kaki5.rotate(Vector3.Zero, Vector3.UnitX, 35);
            var kaki6 = new Asset3d(new Vector3(0.0f, 0.8f, 0.3f));
            kaki6.createEllipsoid(-3.5f, -0.5f, 1f, 0.2f, 0.5f, 0.2f, 10, 20);
            kaki6.rotate(Vector3.Zero, Vector3.UnitX, 35);
            var kaki7 = new Asset3d(new Vector3(0.0f, 0.8f, 0.3f));
            kaki7.createEllipsoid(-4.5f, -0.2f, 1.5f, 0.2f, 0.5f, 0.2f, 10, 20);
            kaki7.rotate(Vector3.Zero, Vector3.UnitX, 35);
            var kaki8 = new Asset3d(new Vector3(0.0f, 0.8f, 0.3f));
            kaki8.createEllipsoid(-3.5f, -0.2f, 1.5f, 0.2f, 0.5f, 0.2f, 10, 20);
            kaki8.rotate(Vector3.Zero, Vector3.UnitX, 35);
            var kaki9 = new Asset3d(new Vector3(0.0f, 0.8f, 0.3f));
            kaki9.createEllipsoid(-4.5f, 0f, 2f, 0.2f, 0.5f, 0.2f, 10, 20);
            kaki9.rotate(Vector3.Zero, Vector3.UnitX, 35);
            var kaki10 = new Asset3d(new Vector3(0.0f, 0.8f, 0.3f));
            kaki10.createEllipsoid(-3.5f, 0f, 2f, 0.2f, 0.5f, 0.2f, 10, 20);
            kaki10.rotate(Vector3.Zero, Vector3.UnitX, 35);
            //mulut 
            var mulut = new Asset3d(new Vector3(0.4f, 0.4f, 0.4f));
            mulut.createCone(-4f, -3.6f, 0.5f, 0.2f, 0f, 0.1f, 10, 20);
            mulut.rotate(Vector3.Zero, Vector3.UnitX, -90);

            ulat.child.Add(badan1);
            ulat.child.Add(badan2);
            ulat.child.Add(badan3);
            ulat.child.Add(badan4);
            ulat.child.Add(mata1);
            ulat.child.Add(mata2);
            ulat.child.Add(gagangpanjang1);
            ulat.child.Add(gagangpanjang2);
            ulat.child.Add(gagangkecil1);
            ulat.child.Add(gagangkecil2);
            ulat.child.Add(mulut);
            ulat.child.Add(kaki1);
            ulat.child.Add(kaki2);
            ulat.child.Add(kaki3);
            ulat.child.Add(kaki4);
            ulat.child.Add(kaki5);
            ulat.child.Add(kaki6);
            ulat.child.Add(kaki7);
            ulat.child.Add(kaki8);
            ulat.child.Add(kaki9);
            ulat.child.Add(kaki10);
            //ulat.child.Add(bawah);
            objectList.Add(ulat);
            #endregion
            // CONE
            /*var cone1 = new Asset3d(new Vector3(1f, 1f, 1f));
            cone1.createCone(0, 0, 0, 0.5f, 0.5f, 0.5f, 100, 100);
            objectList.Add(cone1);*/

            // TORUS
            /*var torus1 = new Asset3d(new Vector3(1f, 1f, 1f));
            torus1.createTorus(0, 2, 0, 0.5f, 0.1f, 100, 100);
            objectList.Add(torus1);*/

            foreach (Asset3d i in objectList)
            {
                i.load(Size.X, Size.Y);
            }
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);

            float time = (float)args.Time; // Deltatime ==> waktu antara frame sebelumnya ke frame berikutnya, gunakan untuk animasi

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit); // DepthBufferBit juga harus di clear karena kita memakai depth testing.

            /*var angle1 = 100;*/

            foreach (Asset3d i in objectList)
            {
                i.render(_camera.GetViewMatrix(), _camera.GetProjectionMatrix());
                /*  i.rotate(Vector3.Zero, Vector3.UnitY, 45 * time);
                  foreach (Asset3d j in i.child)
                  {
                      j.rotate(Vector3.Zero, Vector3.UnitY, 10 * time);
                  }*/
            }

            if (a >= 0 && a <= 500)
            {
                if (a <= 250)
                {
                    objectList[0].child[1].rotate(objectList[0].child[1].objectCenter, Vector3.UnitZ, -100 * time);
                    objectList[0].child[2].rotate(objectList[0].child[2].objectCenter, Vector3.UnitZ, 100 * time);
                    //ulat
                    objectList[2].child[11].rotate(objectList[2].child[11].objectCenter, Vector3.UnitY, -150 * time);
                    objectList[2].child[12].rotate(objectList[2].child[12].objectCenter, Vector3.UnitY, -150 * time);
                    objectList[2].child[13].rotate(objectList[2].child[13].objectCenter, Vector3.UnitY, -150 * time);
                    objectList[2].child[14].rotate(objectList[2].child[14].objectCenter, Vector3.UnitY, -150 * time);
                    objectList[2].child[15].rotate(objectList[2].child[15].objectCenter, Vector3.UnitY, -150 * time);
                    objectList[2].child[16].rotate(objectList[2].child[16].objectCenter, Vector3.UnitY, -150 * time);
                    objectList[2].child[17].rotate(objectList[2].child[17].objectCenter, Vector3.UnitY, -150 * time);
                    objectList[2].child[18].rotate(objectList[2].child[18].objectCenter, Vector3.UnitY, -150 * time);
                    objectList[2].child[19].rotate(objectList[2].child[19].objectCenter, Vector3.UnitY, -150 * time);
                    objectList[2].child[20].rotate(objectList[2].child[20].objectCenter, Vector3.UnitY, -150 * time);
                    // ANT
                    objectList[1].child[23].rotate(objectList[1].child[23].objectCenter, Vector3.UnitY, -100 * time);
                    objectList[1].child[24].rotate(objectList[1].child[24].objectCenter, Vector3.UnitY, 100 * time);
                    if (b <= 10)
                    {
                        objectList[0].translate(0, 0.00025f, 0);
                        objectList[2].translate(0.00025f, 0, 0);
                    }
                }
                else
                {
                    objectList[0].child[1].rotate(objectList[0].child[1].objectCenter, Vector3.UnitZ, 100 * time);
                    objectList[0].child[2].rotate(objectList[0].child[2].objectCenter, Vector3.UnitZ, -100 * time);
                    //ulat
                    objectList[2].child[11].rotate(objectList[2].child[11].objectCenter, Vector3.UnitY, 150 * time);
                    objectList[2].child[12].rotate(objectList[2].child[12].objectCenter, Vector3.UnitY, 150 * time);
                    objectList[2].child[13].rotate(objectList[2].child[13].objectCenter, Vector3.UnitY, 150 * time);
                    objectList[2].child[14].rotate(objectList[2].child[14].objectCenter, Vector3.UnitY, 150 * time);
                    objectList[2].child[15].rotate(objectList[2].child[15].objectCenter, Vector3.UnitY, 150 * time);
                    objectList[2].child[16].rotate(objectList[2].child[16].objectCenter, Vector3.UnitY, 150 * time);
                    objectList[2].child[17].rotate(objectList[2].child[17].objectCenter, Vector3.UnitY, 150 * time);
                    objectList[2].child[18].rotate(objectList[2].child[18].objectCenter, Vector3.UnitY, 150 * time);
                    objectList[2].child[19].rotate(objectList[2].child[19].objectCenter, Vector3.UnitY, 150 * time);
                    objectList[2].child[20].rotate(objectList[2].child[20].objectCenter, Vector3.UnitY, 150 * time);
                    // ANT
                    objectList[1].child[23].rotate(objectList[1].child[23].objectCenter, Vector3.UnitY, 100 * time);
                    objectList[1].child[24].rotate(objectList[1].child[24].objectCenter, Vector3.UnitY, -100 * time);
                    if (b <= 10)
                    {
                        objectList[0].translate(0, 0.0005f, 0);
                        objectList[2].translate(0.0005f, 0, 0);
                    }
                }
            }
            a += 1;

            if (a > 500)
            {
                a = 0;
                b += 1;
            }

            SwapBuffers();
        }

        protected override void OnMouseWheel(MouseWheelEventArgs e)
        {
            base.OnMouseWheel(e);
            _camera.Fov = _camera.Fov - e.OffsetY;
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);

            float time = (float)args.Time; //Deltatime ==> waktu antara frame sebelumnya ke frame berikutnya, gunakan untuk animasi

            if (!IsFocused)
            {
                return; //Reject semua input saat window bukan focus.
            }

            var input = KeyboardState;

            if (input.IsKeyDown(Keys.Escape))
            {
                Close();
            }

            float cameraSpeed = 5f;

            if (KeyboardState.IsKeyDown(Keys.X))
            {
                foreach (Asset3d i in objectList)
                {
                    i.rotate(Vector3.Zero, Vector3.UnitY, 45 * cameraSpeed * (float)args.Time);
                }
            }

            if (KeyboardState.IsKeyDown(Keys.C))
            {
                foreach (Asset3d i in objectList)
                {
                    i.rotate(Vector3.Zero, Vector3.UnitY, -45 * cameraSpeed * (float)args.Time);
                }
            }

            if (KeyboardState.IsKeyDown(Keys.V))
            {
                foreach (Asset3d i in objectList)
                {
                    i.rotate(Vector3.Zero, Vector3.UnitX, 45 * cameraSpeed * (float)args.Time);
                }
            }

            if (KeyboardState.IsKeyDown(Keys.B))
            {
                foreach (Asset3d i in objectList)
                {
                    i.rotate(Vector3.Zero, Vector3.UnitX, -45 * cameraSpeed * (float)args.Time);
                }
            }

            if (KeyboardState.IsKeyDown(Keys.W))
            {
                _camera.Position += _camera.Front * cameraSpeed * (float)args.Time;
            }

            if (KeyboardState.IsKeyDown(Keys.S))
            {
                _camera.Position -= _camera.Front * cameraSpeed * (float)args.Time;
            }

            if (KeyboardState.IsKeyDown(Keys.A))
            {
                _camera.Position -= _camera.Right * cameraSpeed * (float)args.Time;
            }

            if (KeyboardState.IsKeyDown(Keys.D))
            {
                _camera.Position += _camera.Right * cameraSpeed * (float)args.Time;
            }

            if (KeyboardState.IsKeyDown(Keys.Space))
            {
                _camera.Position += _camera.Up * cameraSpeed * (float)args.Time;
            }

            if (KeyboardState.IsKeyDown(Keys.Z))
            {
                _camera.Position -= _camera.Up * cameraSpeed * (float)args.Time;
            }

            /*var mouse = MouseState;
            var sensitivity = 0.2f;

            if (_firstMove)
            {
                _lastPos = new Vector2(mouse.X, mouse.Y);
                _firstMove = false;
            }
            else
            {
                var deltaX = mouse.X - _lastPos.X;
                var deltaY = mouse.Y - _lastPos.Y;
                _lastPos = new Vector2(mouse.X, mouse.Y);
                _camera.Yaw += deltaX * sensitivity;
                _camera.Pitch -= deltaY * sensitivity;
            }*/

            if (KeyboardState.IsKeyDown(Keys.N))
            {
                var axis = new Vector3(0, 1, 0);
                _camera.Position -= _objectPos;
                _camera.Position = Vector3.Transform(
                    _camera.Position,
                    generateArbRotationMatrix(axis, _objectPos,
                    _rotationSpeed).ExtractRotation());
                _camera.Position += _objectPos;
                _camera._front = -Vector3.Normalize(_camera.Position - _objectPos);
            }

            if (KeyboardState.IsKeyDown(Keys.Comma))
            {
                var axis = new Vector3(0, 1, 0);
                _camera.Position -= _objectPos;
                _camera.Yaw -= _rotationSpeed;
                _camera.Position = Vector3.Transform(_camera.Position,
                    generateArbRotationMatrix(axis, _objectPos, -_rotationSpeed)
                    .ExtractRotation());
                _camera.Position += _objectPos;

                _camera._front = -Vector3.Normalize(_camera.Position - _objectPos);
            }
        }

        public Matrix4 generateArbRotationMatrix(Vector3 axis, Vector3 center, float degree)
        {
            var rads = MathHelper.DegreesToRadians(degree);

            var secretFormula = new float[4, 4] {
                { (float)Math.Cos(rads) + (float)Math.Pow(axis.X, 2) * (1 - (float)Math.Cos(rads)), axis.X* axis.Y * (1 - (float)Math.Cos(rads)) - axis.Z * (float)Math.Sin(rads),    axis.X * axis.Z * (1 - (float)Math.Cos(rads)) + axis.Y * (float)Math.Sin(rads),   0 },
                { axis.Y * axis.X * (1 - (float)Math.Cos(rads)) + axis.Z * (float)Math.Sin(rads),   (float)Math.Cos(rads) + (float)Math.Pow(axis.Y, 2) * (1 - (float)Math.Cos(rads)), axis.Y * axis.Z * (1 - (float)Math.Cos(rads)) - axis.X * (float)Math.Sin(rads),   0 },
                { axis.Z * axis.X * (1 - (float)Math.Cos(rads)) - axis.Y * (float)Math.Sin(rads),   axis.Z * axis.Y * (1 - (float)Math.Cos(rads)) + axis.X * (float)Math.Sin(rads),   (float)Math.Cos(rads) + (float)Math.Pow(axis.Z, 2) * (1 - (float)Math.Cos(rads)), 0 },
                { 0, 0, 0, 1}
            };
            var secretFormulaMatix = new Matrix4
            (
                new Vector4(secretFormula[0, 0], secretFormula[0, 1], secretFormula[0, 2], secretFormula[0, 3]),
                new Vector4(secretFormula[1, 0], secretFormula[1, 1], secretFormula[1, 2], secretFormula[1, 3]),
                new Vector4(secretFormula[2, 0], secretFormula[2, 1], secretFormula[2, 2], secretFormula[2, 3]),
                new Vector4(secretFormula[3, 0], secretFormula[3, 1], secretFormula[3, 2], secretFormula[3, 3])
            );

            return secretFormulaMatix;
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);
            _camera.AspectRatio = Size.X / (float)Size.Y;

            GL.Viewport(0, 0, Size.X, Size.Y);
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButton.Left)
            {
                float _x = (MousePosition.X - Size.X / 2) / (Size.X / 2);
                float _y = -(MousePosition.Y - Size.X / 2) / (Size.Y / 2);

                Console.WriteLine("x = " + _x + "; y = " + _y + ";");
            }
        }
    }
}
