using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace f74122161_practice_6_1
{
    public partial class Form1 : Form
    {
        Panel map;
        Panel itemBar;
        int holdItem = 1;
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.Scroll += new ScrollEventHandler(Form1_Scroll);
            this.Resize += new EventHandler(Form1_ChangeSize);
        }
        private void Form1_Scroll(object sender, ScrollEventArgs e)
        {
            // move the item bar with the form
            int x = (this.Width - itemBar.Width) / 2;//center the item bar
            itemBar.Location = new Point(x, this.Height - 128);
        }

        private void Form1_ChangeSize(object sender, EventArgs e)
        {
            // move the item bar with the form
            int x = (this.Width - itemBar.Width) / 2;//center the item bar
            itemBar.Location = new Point(x, this.Height - 128);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Hide();
            pictureBox1.Hide();
            pictureBox2.Hide();
            // add a scroll bar to the form
            this.AutoScroll = true;
            map = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(64 * 30, 64 * 15),
                BackColor = Color.Transparent
            };
            // lock scoll with the mouse wheel
            map.MouseWheel += new MouseEventHandler((object s, MouseEventArgs ee) => ((HandledMouseEventArgs)ee).Handled = true);
            itemBar = new Panel
            {
                Location = new Point(64 * 3, this.Height - 128),
                Size = new Size(48 * 9, 48),
                BackColor = Color.Transparent
            };
            // fix itemBar to the bottom
            // itemBar.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
            this.Controls.Add(map);
            GenerateMap(map);
            GenerateItemBar(itemBar);
            map.MouseClick += new MouseEventHandler(Map_Click);
            this.Controls.Add(itemBar);
            itemBar.BringToFront();

            // add a player to the form
            PictureBox player = new PictureBox
            {
                BackgroundImage = Image.FromFile("../../pic/steve.png"),
                BackgroundImageLayout = ImageLayout.Stretch,
                BackColor = Color.Transparent,
                Location = new Point(100, 128),
                Size = new Size(64, 128),
            };
            this.Controls.Add(player);
            player.BringToFront();
        }



        private void GenerateItemBar(Panel itemBar)
        {
            PictureBox pictureBox = new PictureBox
            {
                BackgroundImage = Image.FromFile("../../pic/itemBar.png"),
                BackgroundImageLayout = ImageLayout.Stretch,
                Location = new Point(0, 0),
                Size = new Size(48 * 9, 48),
                BackColor = GetColorForBlockType(Block.BlockType.GRASS)
            };
            itemBar.Controls.Add(pictureBox);
            PictureBox itemGrass = new PictureBox
            {
                BackgroundImage = Image.FromFile("../../pic/grass.png"),
                BackgroundImageLayout = ImageLayout.Stretch,
                Location = new Point(8, 8),
                Size = new Size(32, 32),
                BackColor = GetColorForBlockType(Block.BlockType.GRASS)
            };
            PictureBox itemDirt = new PictureBox
            {
                BackgroundImage = Image.FromFile("../../pic/dirt.png"),
                BackgroundImageLayout = ImageLayout.Stretch,
                Location = new Point(48 + 8, 8),
                Size = new Size(32, 32),
                BackColor = GetColorForBlockType(Block.BlockType.DIRT)
            };
            PictureBox hold = new PictureBox
            {
                BackgroundImage = Image.FromFile("../../pic/hold.png"),
                BackgroundImageLayout = ImageLayout.Stretch,
                Location = new Point(0, 0),
                Size = new Size(48, 48),
            };
            itemBar.Controls.Add(itemDirt);
            itemBar.Controls.Add(itemGrass);
            itemBar.Controls.Add(hold);
            itemBar.BringToFront();
            hold.BringToFront();
            itemGrass.BringToFront();
            itemDirt.BringToFront();
        }

        private void Map_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == MouseButtons.Right)
            {
                Point coordinates = me.Location;
                // if exist block in the same position, return
                foreach (Control control in map.Controls)
                {
                    if (control is PictureBox)
                    {
                        PictureBox innerPictureBox = (PictureBox)control;
                        if (((int)innerPictureBox.Location.X / 64 * 64 == ((int)coordinates.X / 64 * 64)) && ((int)innerPictureBox.Location.Y / 64 * 64 == ((int)coordinates.Y / 64 * 64)))
                        {
                            return;
                        }
                    }
                }
                Block.BlockType type;
                string imagePath;

                if (holdItem == 1)
                {
                    type = Block.BlockType.GRASS;
                    imagePath = "../../pic/grass.png";
                }
                else if (holdItem == 2)
                {
                    type = Block.BlockType.DIRT;
                    imagePath = "../../pic/dirt.png";
                }
                else
                {
                    return; // No valid item selected
                }

                Vector2F position = new Vector2F(coordinates.X, coordinates.Y);
                Console.WriteLine((int)position.X / 64 * 64);
                Console.WriteLine((int)position.Y / 64 * 64);
                Block block = new Block(position, type);

                PictureBox pictureBox = new PictureBox
                {
                    BackgroundImage = Image.FromFile(imagePath),
                    BackgroundImageLayout = ImageLayout.Stretch,
                    Location = new Point((int)position.X / 64 * 64, (int)position.Y / 64 * 64),
                    Size = new Size(64, 64),
                    BackColor = GetColorForBlockType(type),
                };
                pictureBox.Enabled = false;
                block.Picture = pictureBox;
                map.Controls.Add(pictureBox);
            }
            else if (me.Button == MouseButtons.Left)
            {
                Point coordinates = me.Location;
                Vector2F position = new Vector2F(coordinates.X, coordinates.Y);
                Console.WriteLine((int)position.X / 64 * 64);
                Console.WriteLine((int)position.Y / 64 * 64);
                foreach (Control control in map.Controls)
                {
                    if (control is PictureBox)
                    {
                        PictureBox innerPictureBox = (PictureBox)control;
                        Console.WriteLine(innerPictureBox.Location);
                        if (((int)innerPictureBox.Location.X / 64 * 64 == ((int)position.X / 64 * 64)) && ((int)innerPictureBox.Location.Y / 64 * 64 == ((int)position.Y / 64 * 64)))
                        {
                            Console.WriteLine("Remove");
                            map.Controls.Remove(innerPictureBox);
                            innerPictureBox.Dispose();
                            break;
                        }
                    }
                }
            }
        }

        private void GenerateMap(Panel map)
        {
            int mapWidth = 30;
            int mapHeight = 15;
            for (int y = 4; y < 5; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    Block.BlockType type = Block.BlockType.GRASS;
                    Vector2F position = new Vector2F(x * 64, y * 64);
                    Block block = new Block(position, type);

                    PictureBox pictureBox = new PictureBox
                    {
                        BackgroundImage = Image.FromFile("../../pic/grass.png"),
                        BackgroundImageLayout = ImageLayout.Stretch,
                        Location = new Point((int)position.X, (int)position.Y),
                        Size = new Size(64, 64),
                        BackColor = GetColorForBlockType(type)
                    };
                    pictureBox.Enabled = false;
                    block.Picture = pictureBox;
                    map.Controls.Add(pictureBox);
                }
            }
            for (int y = 5; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    Block.BlockType type = Block.BlockType.STONE;
                    Vector2F position = new Vector2F(x * 64, y * 64);
                    Block block = new Block(position, type);

                    PictureBox pictureBox = new PictureBox
                    {
                        BackgroundImage = Image.FromFile("../../pic/stone.png"),
                        BackgroundImageLayout = ImageLayout.Stretch,
                        Location = new Point((int)position.X, (int)position.Y),
                        Size = new Size(64, 64),
                        BackColor = GetColorForBlockType(type)
                    };
                    pictureBox.Enabled = false;
                    block.Picture = pictureBox;
                    map.Controls.Add(pictureBox);
                }
            }
            map.BringToFront(); // Ensure the map panel is in front
        }

        private Color GetColorForBlockType(Block.BlockType type)
        {
            switch (type)
            {
                case Block.BlockType.WATER:
                    return Color.Blue;
                case Block.BlockType.GRASS:
                    return Color.Green;
                case Block.BlockType.DIRT:
                    return Color.Brown;
                case Block.BlockType.STONE:
                    return Color.Gray;
                default:
                    return Color.White;
            }
        }

        public class Vector2F
        {
            float _x, _y; public float X { get => _x; set => _x = value; }
            public float Y { get => _y; set => _y = value; }
            public Vector2F(float x, float y) { _x = x; _y = y; }
            public Vector2F() { _x = _y = 0; }
            public static Vector2F operator *(Vector2F a, float b) => new Vector2F(a._x * b, a._y * b);
            public static Vector2F operator /(Vector2F a, float b) => new Vector2F(a._x / b, a._y / b);
            public static Vector2F operator +(Vector2F a, Vector2F b) => new Vector2F(a._x + b._x, a._y + b._y);
            public static Vector2F operator -(Vector2F a, Vector2F b) => new Vector2F(a._x - b._x, a._y - b._y);
            public float length() => (float)Math.Sqrt(_x * _x + _y * _y); public override string ToString() { return $"({_x:F4}, {_y:F4})"; }
        }

        public class Block
        {
            public readonly Vector2F Position;
            public readonly BlockType Type;
            public PictureBox Picture;

            public enum BlockType
            {
                WATER,
                GRASS,
                DIRT,
                STONE,
            }

            public Block(Vector2F position, BlockType type)
            {
                Position = position;
                Type = type;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D1)
            {
                holdItem = 1;
                // move the hold item to the left
                itemBar.Controls[2].Location = new Point(0, 0);
            }
            else if (e.KeyCode == Keys.D2)
            {
                holdItem = 2;
                // move the hold item to the right
                itemBar.Controls[2].Location = new Point(48, 0);
            }
        }
    }
}
