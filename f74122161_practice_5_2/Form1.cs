using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace f74122161_practice_5_2
{
    public partial class Form1 : Form
    {
        bool agent1 = false;
        bool agent2 = false;
        bool agent3 = false;

        public static TextBox hiver;
        TextBox hp;
        public static int hp_value = 3, nums_of_enemy = 10, pr_value = 10;
        TextBox pr;
        List<Label> mapList = new List<Label>();
        bool[][] map = new bool[3][] { new bool[11], new bool[11], new bool[11] };
        public static List<Agent> agentList = new List<Agent>();

        private Timer enemyTimer, actionTimer;
        private int enemyCount = 0;

        public Form1()
        {
            InitializeComponent();
            button2.Hide();
            checkBox1.Hide();
            checkBox2.Hide();
            checkBox3.Hide();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            enemyTimer = new Timer();
            enemyTimer.Interval = 2000; // 2 second
            enemyTimer.Tick += new EventHandler(OnEnemyTimerTick);

            actionTimer = new Timer();
            actionTimer.Interval = 1000; // 1 second interval
            actionTimer.Tick += new EventHandler(OnActionTimerTick);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                agent1 = true;
            }
            if (checkBox2.Checked)
            {
                agent2 = true;
            }
            if (checkBox3.Checked)
            {
                agent3 = true;
            }
            button2.Hide();
            checkBox1.Hide();
            checkBox2.Hide();
            checkBox3.Hide();
            start_action();
        }

        private void start_action()
        {
            // TODO
            CreateLableGrid(ref mapList);
            CreateTextBox(ref hiver, ref hp, ref pr);
            CreateAgentList(ref agentList);
            hiver.Text = "";
            hiver.Multiline = true;
            hp.Text = hp_value.ToString() + "/" + nums_of_enemy.ToString();
            pr.Text = pr_value.ToString();

            // Start the enemy generation timer
            enemyTimer.Start();
            actionTimer.Start(); // Start the action timer
        }

        private void OnEnemyTimerTick(object sender, EventArgs e)
        {
            Console.WriteLine("Enemy timer ticked");
            if (nums_of_enemy > 0)
            {
                GenerateEnemy();
                nums_of_enemy--;
            }
            else
            {
                enemyTimer.Stop();
            }
        }
        private void OnActionTimerTick(object sender, EventArgs e)
        {
            // Perform the desired action here
            if (Form1.pr_value < 99) Form1.pr_value += 1;
            Console.WriteLine("Action timer ticked");
            for (int i = 0; i < agentList.Count; i++)
            {
                agentList[i].OnCooldownElapsed();
                if (agentList[i].onMap)
                    agentList[i].label.Text = agentList[i].label.Text.Split('\n')[0] + "\n" + agentList[i].hp + "/" + agentList[i].max_hp + '\n' + agentList[i].skill_cd;
                Console.WriteLine(agentList[i].hp);
            }
            hp.Text = hp_value.ToString() + "/" + nums_of_enemy.ToString();
            pr.Text = pr_value.ToString();
        }

        private void GenerateEnemy()
        {
            enemyCount++;
            Label enemyLabel = new Label();
            enemyLabel.BorderStyle = BorderStyle.FixedSingle;
            enemyLabel.Size = new Size(50, 50);
            enemyLabel.Location = new Point(100, 130); // Adjust location as needed
            enemyLabel.BackColor = Color.Yellow; // Example color for enemy
            this.Controls.Add(enemyLabel);
            enemyLabel.BringToFront(); // Ensure the enemy label is in front of other controls

            // Create an Enemy object and start its movement
            Enemy enemy = new Enemy(1500, 500, 50, 4, ref enemyLabel);
            enemyLabel.Text = $"{enemy.hp}"; // Example text for enemy

            // Timer to move the enemy and check for collision
            Timer moveTimer = new Timer();
            moveTimer.Interval = 50; // Adjust interval as needed
            moveTimer.Tick += (s, e) =>
            {
                for (int i = 0; i < agentList.Count; i++)
                {
                    if (enemy.CheckCollision(agentList[i].label) && agentList[i].onMap)
                    {
                        agentList[i].hp -= (enemy.attack - agentList[i].defense) / 40;
                        if (agentList[i].hp <= 0)
                        {
                            agentList[i].onMap = false;
                            agentList[i].label.Location = agentList[i].lastLocation;
                            agentList[i].hp = agentList[i].max_hp;
                            agentList[i].skill_cd = 0;
                            agentList[i].label.Text = agentList[i].label.Text.Split('\n')[0] + "\n" + agentList[i].cost;
                        }
                        enemy.hp -= (agentList[i].attack - enemy.defense) / 20;
                        enemyLabel.Text = $"{enemy.hp}"; // Example text for enemy
                        if (enemy.hp <= 0)
                        {
                            enemyCount--;
                            this.Controls.Remove(enemyLabel); // Remove enemy label from form
                            moveTimer.Stop(); // Stop the timer
                            if (enemyCount == 0 && nums_of_enemy == 0)
                            {
                                MessageBox.Show("You Win");
                                this.Close();
                            }
                        }
                        return;
                    }
                }
                enemy.Move();
                if (enemy.CheckCollision(mapList[21]))
                {
                    enemyCount--;
                    hp_value--; // Decrement hp
                    if (hp_value == 0)
                    {
                        MessageBox.Show("Game Over");
                        this.Close();
                    }
                    hp.Text = hp_value.ToString() + "/" + nums_of_enemy.ToString();
                    this.Controls.Remove(enemyLabel); // Remove enemy label from form
                    moveTimer.Stop(); // Stop the timer
                    if (enemyCount == 0 && nums_of_enemy == 0)
                    {
                        MessageBox.Show("You Win");
                        this.Close();
                    }
                }
            };
            moveTimer.Start();
        }

        private void CreateLableGrid(ref List<Label> agentList)
        {
            int lableWidth = 70;
            int lableHeight = 70;
            int spacing = 0;
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 11; col++)
                {
                    Label lable = new Label();
                    lable.BorderStyle = BorderStyle.FixedSingle;
                    lable.Size = new Size(lableWidth, lableHeight);
                    lable.Location = new Point(col * (lableWidth + spacing), row * (lableHeight + spacing) + 50);
                    lable.Text = $"Lable {row * 11 + col + 1}";
                    this.Controls.Add(lable);
                    agentList.Add(lable);
                }
            }
            agentList[11].BackColor = Color.Red;
            agentList[21].BackColor = Color.Blue;
        }

        private void CreateTextBox(ref TextBox textBox1, ref TextBox textBox2, ref TextBox textBox3)
        {
            textBox1 = new TextBox();
            textBox1.Size = new Size(100, 50);
            textBox1.Location = new Point(this.Width - 100, 0);
            this.Controls.Add(textBox1);

            textBox2 = new TextBox();
            textBox2.Size = new Size(100, 50);
            textBox2.Location = new Point(0, 270);
            this.Controls.Add(textBox2);

            textBox3 = new TextBox();
            textBox3.Size = new Size(100, 50);
            textBox3.Location = new Point(this.Width - 100, 270);
            this.Controls.Add(textBox3);
        }

        private void CreateAgentList(ref List<Agent> agentList)
        {
            int x = 0;
            if (agent1)
            {
                Label lable = new Label();
                lable.BorderStyle = BorderStyle.FixedSingle;
                lable.Size = new Size(70, 70);
                lable.Text = "Cardigan" + "\n" + "18";
                lable.Location = new Point(x, 350);
                this.Controls.Add(lable);
                lable.BringToFront();

                x += 70;
                agentList.Add(new Cardigan(ref lable));
            }
            if (agent2)
            {
                Label lable = new Label();
                lable.BorderStyle = BorderStyle.FixedSingle;
                lable.Size = new Size(70, 70);
                lable.Text = "Myrtle" + "\n" + "10";
                lable.Location = new Point(x, 350);
                this.Controls.Add(lable);
                x += 70;
                agentList.Add(new Myrtle(ref lable));
                lable.BringToFront();
            }
            if (agent3)
            {
                Label lable = new Label();
                lable.BorderStyle = BorderStyle.FixedSingle;
                lable.Size = new Size(70, 70);
                lable.Text = "Melantha" + "\n" + "15";
                lable.Location = new Point(x, 350);
                this.Controls.Add(lable);
                lable.BringToFront();
                agentList.Add(new Melantha(ref lable));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Show();
            checkBox1.Show();
            checkBox2.Show();
            checkBox3.Show();
            button1.Hide();
        }

        private class Enemy
        {
            public int hp;
            public int attack;
            public int speed;
            public Label label;
            public int defense;

            public Enemy(int hp, int attack, int defense, int speed, ref Label label)
            {
                this.hp = hp;
                this.attack = attack;
                this.speed = speed;
                this.label = label;
                this.defense = defense;

                // moveTimer = new Timer();
                // moveTimer.Interval = 50;
                // moveTimer.Tick += MoveRight;
                // moveTimer.Start();
            }

            public void Move()
            {
                label.Location = new Point(label.Location.X + speed, label.Location.Y);
            }

            public bool CheckCollision(Label target)
            {
                return label.Bounds.IntersectsWith(target.Bounds);
            }
        }
        public abstract class Agent
        {
            public int hp, max_hp;
            public int attack, defense;
            public Label label;
            public int skill_cd, cost;
            public int duration;
            private bool isDragging = false;
            public Point dragStartPoint, lastLocation;
            public bool onMap = false;
            public Form1 form1;

            public Agent(ref Label label)
            {
                this.max_hp = hp;
                this.label = label;
                this.label.MouseDown += Label_MouseDown;
                this.label.MouseMove += Label_MouseMove;
                this.label.MouseUp += Label_MouseUp;
                this.label.MouseEnter += Label_MouseEnter;
            }

            private bool collision(Label target)
            {
                return label.Bounds.IntersectsWith(target.Bounds);
            }

            private void Label_MouseDown(object sender, MouseEventArgs e)
            {
                if (onMap && e.Button == MouseButtons.Left)
                {
                    if (skill_cd == 0)
                    {
                        this.label.BackColor = Color.Gray;
                        Skill();
                        StartCooldown();
                    }
                    return;
                }
                else if (onMap && e.Button == MouseButtons.Right)
                {
                    // remove from map
                    onMap = false;
                    this.label.Location = lastLocation;
                    this.hp = this.max_hp;
                    this.skill_cd = 0;
                    this.label.Text = this.label.Text.Split('\n')[0] + "\n" + this.cost;
                    return;
                }
                lastLocation = this.label.Location;
                if (e.Button == MouseButtons.Left)
                {
                    isDragging = true;
                    dragStartPoint = e.Location;
                }
            }

            private void Label_MouseMove(object sender, MouseEventArgs e)
            {
                if (onMap)
                {
                    return;
                }
                if (isDragging)
                {
                    label.Left += e.X - dragStartPoint.X;
                    label.Top += e.Y - dragStartPoint.Y;
                }
            }

            private void Label_MouseUp(object sender, MouseEventArgs e)
            {
                if (onMap)
                {
                    return;
                }
                if (e.Button == MouseButtons.Left)
                {
                    isDragging = false;
                }

                // Check if the label is in other agent's location
                for (int i = 0; i < Form1.agentList.Count; i++)
                {
                    if (collision(Form1.agentList[i].label) && Form1.agentList[i].onMap)
                    {
                        label.Location = lastLocation;
                        return;
                    }
                }

                if (label.Bounds.IntersectsWith(new Rectangle(0, 50, 770, 260)) && !onMap && Form1.pr_value >= cost)
                {
                    Form1.pr_value -= cost;
                    onMap = true;
                    this.label.Location = new Point((label.Location.X + 35) / 70 * 70, label.Location.Y / 70 * 70 + 50);
                    this.label.BackColor = Color.Gray;
                    this.label.Text = this.label.Text + "\n " + this.hp + "/" + this.max_hp + '\n' + this.skill_cd;
                    StartCooldown();
                }
                else
                {
                    label.Location = lastLocation;
                }
            }

            private void Label_MouseEnter(object sender, EventArgs e)
            {
                if (!onMap)
                {
                    return;
                }
                Form1.hiver.Text = this.label.Text;

            }


            public bool CheckCollision(Label target)
            {
                return label.Bounds.IntersectsWith(target.Bounds);
            }

            public abstract void Skill();
            public abstract void Skill(Form1 form);

            public void StartCooldown()
            {
                skill_cd = this.duration;
            }

            public void OnCooldownElapsed()
            {
                if (skill_cd > 0)
                {
                    this.label.BackColor = Color.Gray;
                    skill_cd--;
                }
                else
                {
                    this.label.BackColor = Color.Green;
                }
            }
        }

        public class Cardigan : Agent
        {
            public Cardigan(ref Label label) : base(ref label)
            {
                hp = 2130;
                max_hp = 2130;
                attack = 305;
                defense = 475;
                cost = 18;
                duration = 20;
            }

            public override void Skill()
            {
                this.hp += (int)(max_hp * 0.4);
                hp = hp > max_hp ? max_hp : hp;
            }

            public override void Skill(Form1 form)
            {
                // form.hp_value += 1;
            }
        }

        public class Myrtle : Agent
        {
            public Myrtle(ref Label label) : base(ref label)
            {
                hp = 1565;
                max_hp = 1565;
                attack = 520;
                defense = 300;
                cost = 10;
                duration = 22;
            }

            public override void Skill()
            {
            }
            public override void Skill(Form1 form)
            {
                Form1.pr_value += 10;
            }
        }
        public class Melantha : Agent
        {
            public Melantha(ref Label label) : base(ref label)
            {
                hp = 2745;
                max_hp = 1565;
                attack = 738;
                defense = 155;
                cost = 15;
                duration = 40;
            }

            public override void Skill()
            {
                attack *= 2;
            }
            public override void Skill(Form1 form)
            {
            }
        }
    }
}
