﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestCall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown("space"))
		{
			/*Rule test_rule1 = gameObject.AddComponent<Rule>();
			Rule test_rule2 = gameObject.AddComponent<Rule>();
			Rule test_rule3 = gameObject.AddComponent<Rule>();

			test_rule1.rule_name = "backstab";
			test_rule2.rule_name = "bounce";
			test_rule3.rule_name = "tictac";

			test_rule1.type = RuleType.points;
			test_rule2.type = RuleType.foul;
			test_rule3.type = RuleType.finisher;*/

			string test_rule1 = "backstab|SCORE";
			string test_rule2 = "bounce|FOUL";
			string test_rule3 = "tictac|FINISHER";

			List<string> temp_list = new List<string>();


			temp_list.Add (test_rule1);
			temp_list.Add (test_rule2);
			temp_list.Add (test_rule3);

			GameObject.FindGameObjectWithTag("TitleText").SendMessage ("makeRandomNameForSport",temp_list);
		}

	}
}
