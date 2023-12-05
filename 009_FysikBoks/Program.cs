Console.Clear();

float[] pos = new float[2];
int[] ballPos = new int[2];

int[] max = {20, 30};
int[] min = {0, 0};

Bold bold = new Bold(0, max, min);
bold.Position[0] = 1.0f;
bold.Position[1] = 25.0f;

while(true) {
pos = bold.Fald();

for(int i = 0; i < 2; i++) ballPos[i] = (int)pos[i];

Console.Clear();

Box.Draw(max, min, ballPos);

Thread.Sleep(1);
}