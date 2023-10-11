using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
    public class ScoreTable
    {
        public List<ScoreElement> scoreTable;

        public ScoreTable() { this.scoreTable = new List<ScoreElement>();}
    }


