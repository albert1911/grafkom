using System.Collections.Generic;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Windowing.Desktop;
using System;
using OpenTK.Mathematics;
using LearnOpenTK.Common;
using System.Drawing;

namespace ConsoleApp2
{
    static class Constants
    {
        public const string path = "../../../Shaders/";
    }
    class Window : GameWindow
    {
        List<Asset3d> objectList = new List<Asset3d>();
        Asset2d[] _object = new Asset2d[4];

        Camera _camera;

        /*bool _firstMove = true;
        Vector2 _lastPos;*/
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

            cockroach.rotate(Vector3.Zero, Vector3.UnitY, -75);
            #endregion

            _object[0] = new Asset2d(new float[1000], new uint[] { }, new float[] { 1, 1, 1, 1 });
            _object[1] = new Asset2d(new float[] { }, new uint[] { }, new float[] { 1, 1, 1, 1 });
            _object[0].updateOnMousePosition(0.305f, -0.045f);
            _object[0].updateOnMousePosition(0.375f, 0.031f);
            _object[0].updateOnMousePosition(0.645f, 0.285f);
            _object[0].updateOnMousePosition(0.8025f, 0.1925f);

            _object[2] = new Asset2d(new float[1000], new uint[] { }, new float[] { 1, 1, 1, 1 });
            _object[3] = new Asset2d(new float[] { }, new uint[] { }, new float[] { 1, 1, 1, 1 });
            _object[2].updateOnMousePosition(0.255f, -0.045f);
            _object[2].updateOnMousePosition(0.175f, 0.031f);
            _object[2].updateOnMousePosition(0.445f, 0.285f);
            _object[2].updateOnMousePosition(0.6025f, 0.1925f);

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

            for (int i = 0; i < _object.Length; i++)
            {
                _object[i].load(Constants.path + "shader2.vert",
                    Constants.path + "shader2.frag");
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
                i.rotate(Vector3.Zero, Vector3.UnitY, 45 * time);
                foreach (Asset3d j in i.child)
                {
                    j.rotate(Vector3.Zero, Vector3.UnitY, 10 * time);
                }
            }

            KeyboardKeyEventArgs e = new KeyboardKeyEventArgs();

            /*var objectCenter = objectList[0].child[14].getRotationResult(Vector3.Zero, Vector3.UnitZ, MathHelper.DegreesToRadians(angle1 * time), objectList[0].child[14].objectCenter);

            if (objectCenter[0] <= 0)
            {
                objectList[0].child[14].rotate(Vector3.Zero, Vector3.UnitZ, 100 * time);
            }
            else
            {
                objectList[0].child[14].rotate(Vector3.Zero, Vector3.UnitZ, -100 * time);
            }*/
            
            if (_object[0].getVerticesLength())
            {
                List<float> _verticesTemp = _object[0].createCurveBezier();
                _object[1].setVertices(_verticesTemp.ToArray());
                _object[1].load(Constants.path + "shader2.vert",
                    Constants.path + "shader2.frag");
                _object[1].render(3);
            }

            if (_object[2].getVerticesLength())
            {
                List<float> _verticesTemp = _object[2].createCurveBezier();
                _object[3].setVertices(_verticesTemp.ToArray());
                _object[3].load(Constants.path + "shader2.vert",
                    Constants.path + "shader2.frag");
                _object[3].render(3);
            }
            _object[2].render(2);

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

                // PENSIL
                /*_object[0].updateOnMousePosition(_x, _y);*/
            }
        }
    }
}
