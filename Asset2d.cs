using LearnOpenTK.Common;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uts_Grafkom
{
    internal class Asset2d
    {
        // SEGITIGA
        float[] _vertices =
        {
        };
        uint[] _indices =
        {
        };
        float[] _colors =
        {
        };

        int _vertexBufferObject;
        int _vertexArrayObject;
        int _elementBufferObject;
        Shader _shader;
        int indexs;
        int[] _pascal;

        public Asset2d(float[] vertices, uint[] indices, float[] colors)
        {
            _vertices = vertices;
            _indices = indices;
            _colors = colors;
            indexs = 0;
        }

        public void load(string shaderVert, string shaderFrag)
        {
            _vertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer,
                _vertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer,
                _vertices.Length * sizeof(float),
                _vertices,
                BufferUsageHint.StaticDraw);
            _vertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(_vertexArrayObject);
            GL.VertexAttribPointer(0, 3,
                VertexAttribPointerType.Float,
                false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

            if (_indices.Length != 0)
            {
                _elementBufferObject = GL.GenBuffer();
                GL.BindBuffer(BufferTarget.ElementArrayBuffer,
                    _elementBufferObject);
                GL.BufferData(BufferTarget.ElementArrayBuffer,
                    _indices.Length * sizeof(uint),
                    _indices, BufferUsageHint.StaticDraw);
            }

            _shader = new Shader(shaderVert, shaderFrag);
        }

        public void render(int pilihan)
        {
            _shader.Use();
            GL.BindVertexArray(_vertexArrayObject);

            if (_indices.Length != 0)
            {
                GL.DrawElements(PrimitiveType.Triangles,
                    _indices.Length,
                    DrawElementsType.UnsignedInt, 0);
            }
            else
            {
                if (pilihan == 0)
                {
                    GL.DrawArrays(PrimitiveType.Triangles,
                    0, 3);
                }
                else if (pilihan == 1)
                {
                    GL.DrawArrays(PrimitiveType.TriangleFan, 0,
                        (_vertices.Length + 1) / 3);
                }
                else if (pilihan == 2)
                {
                    GL.DrawArrays(PrimitiveType.LineStrip,
                        0, indexs);
                }
                else if (pilihan == 3)
                {
                    GL.DrawArrays(PrimitiveType.LineStrip,
                        0, (_vertices.Length + 1) / 3);

                }
            }

            // variable shader uniform di shader.frag
            int vertexColorLocation = GL.GetUniformLocation(_shader.Handle, "ourColor");
            GL.Uniform4(vertexColorLocation, _colors[0], _colors[1], _colors[2], _colors[3]);
        }
        public void createCircle(float centerX, float centerY, float radius)
        {
            _vertices = new float[1080];
            for (int i = 0; i < 360; i++)
            {
                double degInRad = i * Math.PI / 180;
                // x
                _vertices[i * 3] = radius * (float)Math.Cos(degInRad) + centerX;
                // y
                _vertices[i * 3 + 1] = radius * (float)Math.Sin(degInRad) + centerY;
                // z
                _vertices[i * 3 + 2] = 0;
            }
        }
        public void createEllips(float centerX, float centerY, float radiusX, float radiusY)
        {
            _vertices = new float[1080];
            for (int i = 0; i < 360; i++)
            {
                double degInRad = i * Math.PI / 180;
                // x
                _vertices[i * 3] = radiusX * (float)Math.Cos(degInRad) + centerX;
                // y
                _vertices[i * 3 + 1] = radiusY * (float)Math.Sin(degInRad) + centerY;
                // z
                _vertices[i * 3 + 2] = 0;
            }
        }

        public void updateOnMousePosition(float _x, float _y)
        {
            _vertices[indexs * 3] = _x;
            _vertices[indexs * 3 + 1] = _y;
            _vertices[indexs * 3 + 2] = 0;
            indexs++;

            GL.BufferData(BufferTarget.ArrayBuffer,
                _vertices.Length * sizeof(float),
                _vertices,
                BufferUsageHint.StaticDraw);
            GL.VertexAttribPointer(0, 3,
                VertexAttribPointerType.Float,
                false, 3 * sizeof(float), 0);
        }
        public List<int> getRow(int rowIndex)
        {
            List<int> currow = new List<int>();
            //------
            currow.Add(1);
            if (rowIndex == 0)
            {
                return currow;
            }
            //-----
            List<int> prev = getRow(rowIndex - 1);
            for (int i = 1; i < prev.Count; i++)
            {
                int curr = prev[i - 1] + prev[i];
                currow.Add(curr);
            }
            currow.Add(1);
            return currow;
        }
        public List<float> createCurveBezier()
        {
            List<float> _vertices_bezier = new List<float>();
            List<int> pascal = getRow(indexs - 1);
            _pascal = pascal.ToArray();
            for (float t = 0; t <= 1.0f; t += 0.01f)
            {
                Vector2 p = getP(indexs, t);
                _vertices_bezier.Add(p.X);
                _vertices_bezier.Add(p.Y);
                _vertices_bezier.Add(0);
            }

            return _vertices_bezier;
        }
        public Vector2 getP(int n, float t)
        {
            Vector2 p = new Vector2(0, 0);
            float k;
            for (int i = 0; i < n; i++)
            {
                k = (float)Math.Pow((1 - t), n - 1 - i)
                    * (float)Math.Pow(t, i) * _pascal[i];
                p.X += k * _vertices[i * 3];
                p.Y += k * _vertices[i * 3 + 1];
            }
            return p;
        }
        public bool getVerticesLength()
        {
            if (_vertices[0] == 0)
            {
                return false;
            }
            if ((_vertices.Length + 1) / 3 > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void setVertices(float[] _temp)
        {
            _vertices = _temp;
        }
    }
}
