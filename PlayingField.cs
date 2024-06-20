using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_04_03_06_2024
{
    internal class PlayingField
    {
        private int _size;
        private int _counter;
        private int _counterStep;
        private bool _gamePlay;
        private string _winer;
        private List<int> _step;
        private string [,] _field;
        private string Symbol()
        {
            if (_counter == 0)
            {
                _counter++;
                return "X";
            }
            else
            {
                _counter--;
                return "O";
            }
        }
        public PlayingField()
        {
            _size = 3;
            _counter = 0;
            _counterStep = 0;
            _gamePlay = true;
            _step = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            _field = new string[,]
            {
                {"1", "2", "3"},
                {"4", "5", "6"},
                {"7", "8", "9"}
            };

        }
        public int GetStep()
        {
            return _counterStep;
        }
        public void showStep()
        {
            Console.Write($"Доступные шаги: ");
            foreach (var item in _step)
            {
                Console.Write($"{item} ");
            }
        }
        public List<int> getList()
        {
            return _step;
        }
        public string GetWiner()
        {
            return _winer;
        }
        public override string ToString()
        {
            return $"{_field[0,0]}|{_field[0, 1]}|{_field[0, 2]}\n-----\n{_field[1, 0]}|{_field[1, 1]}|{_field[1, 2]}\n-----\n{_field[2, 0]}|{_field[2, 1]}|{_field[2, 2]}";
        }
        public void putSymbol (int step)
        {
            string var = step.ToString();
            int curStep = _counterStep;
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if (this._field[i,j] == var && var != "X" && var != "0")
                    {
                        this._field[i, j] = Symbol();
                        _counterStep++;
                        _step.Remove(step);
                    }
                }
            }
            if (curStep == _counterStep)
            {
                throw new Exception("Не верный выбор");
            }
            if (_counterStep == 9)
            {
                _gamePlay = false;
                _winer = "NoBody";
            }
            this.CheckWiner();
        }
        private void CheckWiner()
        {
            if (_field[0, 0]==_field[0, 1] && _field[0, 0]==_field[0, 2] )
            {
                _gamePlay = false;
                _winer = _field[0, 0];
            }
            else if (_field[1, 0] == _field[1, 1] && _field[1, 0] == _field[1, 2])
            {
                _gamePlay = false;
                _winer = _field[1, 0];
            }
            else if (_field[2, 0] == _field[2, 1] && _field[2, 0] == _field[2, 2])
            {
                _gamePlay = false;
                _winer = _field[2, 0];
            }
            else if (_field[0, 0] == _field[1, 0] && _field[0, 0] == _field[2, 0])
            {
                _gamePlay = false;
                _winer = _field[0, 0];
            }
            else if (_field[0, 1] == _field[1, 1] && _field[0, 1] == _field[2, 1])
            {
                _gamePlay = false;
                _winer = _field[0, 1];
            }
            else if (_field[0, 2] == _field[1, 2] && _field[0, 2] == _field[2, 2])
            {
                _gamePlay = false;
                _winer = _field[0, 2];
            }
            else if (_field[0, 0] == _field[1, 1] && _field[0, 0] == _field[2, 2] || _field[0, 2] == _field[1, 1] && _field[0, 2] == _field[0, 2])
            {
                _gamePlay = false;
                _winer = _field[1, 1];
            }
            else if (_counterStep == 9)
            {
                _gamePlay = false;
                _winer = "NoBody";
            }
            else
            {
                _gamePlay = true;
            }
        }
        public bool IsPlaying()
        {
            return _gamePlay;
        }
    }
}
