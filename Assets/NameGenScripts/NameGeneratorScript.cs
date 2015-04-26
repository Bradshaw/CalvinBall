using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class NameGeneratorScript : MonoBehaviour {

	public List<Rule> received_list = new List<Rule>();

	string[] hyperlative_adjectives = {"super","hyper","retro","ultra"};
	string[] scoring_system_hints = {"backstab","passing","goal","offsider"};
	string[] foul_hints = {"bounce","pit","zone","speed"};
	string[] round_finisher_hints = {"fast","slow","tictac","five","century"};

	string[] strange_words_list = {"cauguer","rattle","kangaroo","wizzle","meditative"};

	string[] last_word_list = {"ball","bullet"," of Death","disc"};

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
		/*if (Input.GetKeyDown("space"))
		{
			Rule test_rule1 = gameObject.AddComponent<Rule>();
			Rule test_rule2 = gameObject.AddComponent<Rule>();
			Rule test_rule3 = gameObject.AddComponent<Rule>();

			test_rule1.rule_name = "backstab";
			test_rule2.rule_name = "bounce";
			test_rule3.rule_name = "tictac";

			test_rule1.type = RuleType.points;
			test_rule2.type = RuleType.foul;
			test_rule3.type = RuleType.finisher;

			List<Rule> temp_list = new List<Rule>();


			temp_list.Add (test_rule1);
			temp_list.Add (test_rule2);
			temp_list.Add (test_rule3);


			GetComponent<TextMesh>().text = makeRandomnameForSport(temp_list);
		}*/
	}

	void makeRandomNameForSport(List<Rule> from_received_list)
	{
		/*for(int i=0;i<from_received_list.Count;i++)
		{
			Debug.Log(from_received_list[i].rule_name);

		}*/
	
		string random_hyperlative = "";
		string random_scoring = "";
		string random_foul = "";
		string random_round_finisher = "";
		string random_last_word = "";

		float hyperlative_probability = 0.8f;
		float scoring_probability = 0.8f;
		float scoring_not_probability = 0;
		float foul_probability = 0.8f;
		float foul_not_probability = 0.8f;
		float finisher_probability = 0.8f;
		float finisher_not_probability = 0.8f;

		float last_word_probability = 0;
	
		Rule test_rule = gameObject.AddComponent<Rule>(); 
		string test_rule_string = from_received_list[Random.Range(0,from_received_list.Count)].ToString();

		string[] test_rule_array = test_rule_string.Split("|");

		string test_rule_name = test_rule_array[0];
		string test_rule_type = test_rule_array[1];

		switch(test_rule_type)
		{
			case "NIL":
				//Debug.Log ("NIL");
			break;
			case "POINTS":
				scoring_probability = -1;
				//Debug.Log ("POINTS");
			break;
			case "FOUL":
				foul_probability = -1;
				//Debug.Log ("FOUL");
			break;
			case "FINISHER":
				finisher_probability = -1;
				//Debug.Log ("FINISHER");
			break;
			default:
			 //Debug.Log ("COCOCOCO");
			break;
		}

		//Show or not the hyperlative part of the name
		if(hyperlative_adjectives.Length > 0 && Random.value > hyperlative_probability)
		{
			random_hyperlative = hyperlative_adjectives[Random.Range(0,hyperlative_adjectives.Length)];
		}

		//Show or not the scoring part of the name
		if(scoring_probability < 0)
		{
			random_scoring = test_rule_name;
		}
		else if(scoring_system_hints.Length > 0 && Random.value > scoring_probability)
		{
			random_scoring = scoring_system_hints[Random.Range(0,scoring_system_hints.Length)];
			
		}
		else if(Random.value > scoring_not_probability)
		{
			random_scoring = strange_words_list[Random.Range(0,strange_words_list.Length)];
		}

		//Show or not the fouls part of the name
		if(foul_probability < 0)
		{
			random_foul = test_rule_name;
		}
		else if(foul_hints.Length > 0 && Random.value > foul_probability)
		{
			random_foul = foul_hints[Random.Range(0,foul_hints.Length)];
			
		}
		else if(Random.value > foul_not_probability)
		{
			random_foul = strange_words_list[Random.Range(0,strange_words_list.Length)];
		}

		//Show or not the round finisher part of the name
		if(finisher_probability < 0)
		{
			random_round_finisher = test_rule_name;
		}
		else if(round_finisher_hints.Length > 0 && Random.value > finisher_probability)
		{
			random_round_finisher = round_finisher_hints[Random.Range(0,round_finisher_hints.Length)];
			
		}
		else if(Random.value > finisher_not_probability)
		{
			random_round_finisher = strange_words_list[Random.Range(0,strange_words_list.Length)];
		}


		//Show or not the last word of the name
		if(last_word_list.Length > 0 && Random.value > 0)
		{
			random_last_word = last_word_list[Random.Range(0,last_word_list.Length)];
			
		}

		string final_mix = "";

		string pre_final_mix = random_hyperlative+random_scoring+random_foul+random_round_finisher+random_last_word; 


		if(pre_final_mix.Length > 1)
		{

			final_mix = pre_final_mix.Substring(0,1).ToUpper() + pre_final_mix.Substring(1,pre_final_mix.Length - 1);
		}

		GetComponent<TextMesh>().text = final_mix;
	}

	string makeRandomNameForSportWithReturn(List<Rule> from_received_list)
	{
		/*for(int i=0;i<from_received_list.Count;i++)
		{
			Debug.Log(from_received_list[i].rule_name);

		}*/
		
		string random_hyperlative = "";
		string random_scoring = "";
		string random_foul = "";
		string random_round_finisher = "";
		string random_last_word = "";
		
		float hyperlative_probability = 0.8f;
		float scoring_probability = 0.8f;
		float scoring_not_probability = 0;
		float foul_probability = 0.8f;
		float foul_not_probability = 0.8f;
		float finisher_probability = 0.8f;
		float finisher_not_probability = 0.8f;
		
		float last_word_probability = 0;
		
		Rule test_rule = gameObject.AddComponent<Rule>(); 
		string test_rule_string = from_received_list[Random.Range(0,from_received_list.Count)].ToString();
		
		string test_rule_name = test_rule_string.Split ("|")[0];
		string test_rule_type = test_rule_string.Split ("|")[1];
		
		
		
		switch(test_rule_type)
		{
		case "NIL":
			//Debug.Log ("NIL");
			break;
		case "POINTS":
			scoring_probability = -1;
			//Debug.Log ("POINTS");
			break;
		case "FOUL":
			foul_probability = -1;
			//Debug.Log ("FOUL");
			break;
		case "FINISHER":
			finisher_probability = -1;
			//Debug.Log ("FINISHER");
			break;
		default:
			//Debug.Log ("COCOCOCO");
			break;
		}
		
		//Show or not the hyperlative part of the name
		if(hyperlative_adjectives.Length > 0 && Random.value > hyperlative_probability)
		{
			random_hyperlative = hyperlative_adjectives[Random.Range(0,hyperlative_adjectives.Length)];
		}
		
		//Show or not the scoring part of the name
		if(scoring_probability < 0)
		{
			random_scoring = test_rule_name;
		}
		else if(scoring_system_hints.Length > 0 && Random.value > scoring_probability)
		{
			random_scoring = scoring_system_hints[Random.Range(0,scoring_system_hints.Length)];
			
		}
		else if(Random.value > scoring_not_probability)
		{
			random_scoring = strange_words_list[Random.Range(0,strange_words_list.Length)];
		}
		
		//Show or not the fouls part of the name
		if(foul_probability < 0)
		{
			random_foul = test_rule_name;
		}
		else if(foul_hints.Length > 0 && Random.value > foul_probability)
		{
			random_foul = foul_hints[Random.Range(0,foul_hints.Length)];
			
		}
		else if(Random.value > foul_not_probability)
		{
			random_foul = strange_words_list[Random.Range(0,strange_words_list.Length)];
		}
		
		//Show or not the round finisher part of the name
		if(finisher_probability < 0)
		{
			random_round_finisher = test_rule_name;
		}
		else if(round_finisher_hints.Length > 0 && Random.value > finisher_probability)
		{
			random_round_finisher = round_finisher_hints[Random.Range(0,round_finisher_hints.Length)];
			
		}
		else if(Random.value > finisher_not_probability)
		{
			random_round_finisher = strange_words_list[Random.Range(0,strange_words_list.Length)];
		}
		
		
		//Show or not the last word of the name
		if(last_word_list.Length > 0 && Random.value > 0)
		{
			random_last_word = last_word_list[Random.Range(0,last_word_list.Length)];
			
		}
		
		string final_mix = "";
		
		string pre_final_mix = random_hyperlative+random_scoring+random_foul+random_round_finisher+random_last_word; 
		
		
		if(pre_final_mix.Length > 1)
		{
			
			final_mix = pre_final_mix.Substring(0,1).ToUpper() + pre_final_mix.Substring(1,pre_final_mix.Length - 1);
		}
		
		return final_mix;
	}

}
