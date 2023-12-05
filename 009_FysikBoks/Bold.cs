using System;

public class Bold {

    // Felter:
    private static float _tyngdekraft = 9.82f;

    private int _n;
    private char _tegn = '■';
    public float _resti = 0.5f;

    private int[] _maxPos = new int[2];
    private int[] _minPos = new int[2];

    private float[] _pos = {0.0f, 0.0f};
    private float[] _fart = {0.0f, 0.0f};
    private float[] _accel = {0.0f, 0.0f};

    // Get, set:
    public float[] Position {get {return _pos;} set {_pos = value;}}
    public float[] Fart {get {return _fart;} set {_fart = value;}}
    public float[] Acceleration {get {return _accel;} set {_accel = value;}}
    public float Restitution {get {return _resti;} set {_resti = value;}}
    
    // Konstruktørere:
    public Bold(int n, char tegn, int[] pos, int[] maxPos, int[] minPos, float resti) {
        _pos[0] = pos[0];
        _pos[1] = pos[1];
        _n = n;
        _tegn = tegn;
        for(int i = 0; i < 2; i++) _maxPos[i] = maxPos[i];
        for(int i = 0; i < 2; i++) _minPos[i] = minPos[i];
        _resti = resti;
    }

    public Bold(int n, int[] maxPos, int[] minPos) {
        _n = n;
        for(int i = 0; i < 2; i++) _maxPos[i] = maxPos[i] - 1;
        for(int i = 0; i < 2; i++) _minPos[i] = minPos[i] + 1;
    }

    // Metoder:
    public float[] Fald() {        
        for(int i = 0; i < 2; i++) _fart[i] += _accel[i]/200;
        _fart[1] -= _tyngdekraft/200;

        for(int i = 0; i < 2; i++) _pos[i] += _fart[i]/200;
        
        for(int i = 0; i < 2; i++) {
            if(_pos[i] > _maxPos[i]) { 
                _pos[i] = _maxPos[i];
                _fart[i] = -_fart[i] * _resti;    
            }
            else if (_pos[i] < _minPos[i]) {
                _pos[i] = _minPos[i];
                _fart[i] = -_fart[i] * _resti; 
            }
        }
        return _pos;
    }
}

public static class Box {
    public static void Draw(int[] max, int[] min, int[] ballPos) {
        string fyld = "█";
        string ender = "██";
        for(int i = 0; i < max[0] - 2; i++) {ender += "█"; fyld += " ";} 
        fyld += "█";
        Console.WriteLine(ender);

        for(int y = max[1]; y > min[1] + 2; y--) {
            if(y == ballPos[1]) {
                Console.WriteLine(fyld.Substring(0, ballPos[0]) + "■" + fyld.Substring(ballPos[0] + 1));
                continue;
            }
            Console.WriteLine(fyld);
        }

        Console.WriteLine(ender);
    }
}