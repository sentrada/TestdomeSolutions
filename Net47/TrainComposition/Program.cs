using System;

namespace TrainComposition
{
    public class Wagon{
        public int Id { get; }

        public Wagon RightTrain { get; private set; }

        public Wagon LeftTrain { get; private set; }

        public Wagon(int id){
            Id=id;
            LeftTrain=null;
            RightTrain=null;
        }
        public void SetRightTrain(Wagon right){
            RightTrain=right;
        }
        public void SetLeftTrain(Wagon left){
            LeftTrain=left;
        }
    }


    public class TrainComposition
    {
        private Wagon _leftMost;
        private Wagon _rightMost;

        public TrainComposition()
        {
            _leftMost = null;
            _rightMost = null;
        }

        public void AttachWagonFromLeft(int wagonId)
        {
            var node = new Wagon(wagonId);
            if (_leftMost != null)
            {
                //trains in composition
                _leftMost.SetLeftTrain(node);
                node.SetRightTrain(_leftMost);
                _leftMost = node;
            }
            else
            {
                SetNewTrain(node);
            }
        }

        public void AttachWagonFromRight(int wagonId)
        {
            var node = new Wagon(wagonId);
            if (_rightMost != null)
            {
                //trains in composition
                _rightMost.SetRightTrain(node);
                node.SetLeftTrain(_rightMost);
                _rightMost = node;
            }
            else
            {
                SetNewTrain(node);
            }
        }

        private void SetNewTrain(Wagon node)
        {
            _leftMost = node;
            _rightMost = node;
        }

        public int DetachWagonFromLeft()
        {
            var wagonId = 0;
            if (_leftMost != null)
            {
                wagonId = _leftMost.Id;
                _leftMost = _leftMost.RightTrain;
            }

            return wagonId;
        }

        public int DetachWagonFromRight()
        {
            var wagonId = 0;
            if (_rightMost != null)
            {
                wagonId = _rightMost.Id;
                _rightMost = _rightMost.LeftTrain;
            }

            return wagonId;
        }

        public static void Main(string[] args)
        {
            TrainComposition train = new TrainComposition();
            train.AttachWagonFromLeft(7);
            train.AttachWagonFromLeft(13);
            Console.WriteLine(train.DetachWagonFromRight()); // 7 
            Console.WriteLine(train.DetachWagonFromLeft()); // 13
        }
    }
}