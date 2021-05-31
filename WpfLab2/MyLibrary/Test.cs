using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace MyLibrary
{
    [XmlInclude(typeof(Exam))]
    [XmlInclude(typeof(FinalExam))]
    [XmlInclude(typeof(Challenge))]
    [Serializable]
    public class Test
    {
        #region Public Variables

        public int Score => _score;

        public List<Question> QuestionsList => questionsList;

        public string StudentName
        {
            get => _studentName;
            set => _studentName = string.IsNullOrEmpty(value) ? "No student name" : value;
        }

        public string TestName
		{
            get => _testName;
            set => _testName = string.IsNullOrEmpty(value) ? "No test name" : value;
		}

        #endregion


        #region Private Variables
        
        private string _studentName;
        internal readonly List<Question> questionsList;
        private int _score;
        private string _testName;

        #endregion

        #region Methods

        public Test() => questionsList = new List<Question>(10);
        

        public void AddTestQuestion(TestQuestion testQuestion)
        {
            questionsList.Add(testQuestion);
        }

        public void GetResult(bool answerResult)
        {
            if (answerResult)
                _score++;
        }

        #endregion
    }
}