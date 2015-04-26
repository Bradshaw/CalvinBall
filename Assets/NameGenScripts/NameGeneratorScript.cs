using UnityEngine;
using System.Collections;

public class NameGeneratorScript : MonoBehaviour {

	string[] hyperlative_adjectives = {"super","hyper","retro","ultra"};
	string[] scoring_system_hints = {"backstab","passing","goal","offsider"};
	string[] foul_hints = {"bounce","pit","zone","speed"};
	string[] round_finisher_hints = {"fast","slow","tictac","five","century"};

	string[] strange_words_list = {"cauguer","rattle","kangaroo","wizzle"};

	string[] last_word_list = {"ball","bullet"," of Death","disc"};


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown("space"))
			GetComponent<TextMesh>().text = makeRandomNameForSport();
	}

	string makeRandomNameForSport()
	{
		string final_name = "";

		string random_hyperlative = "";
		string random_scoring = "";
		string random_foul = "";
		string random_round_finisher = "";
		string random_last_word = "";

		//Show or not the hyperlative part of the name
		if(hyperlative_adjectives.Length > 0 && Random.value > 0.7)
		{
			random_hyperlative = hyperlative_adjectives[Random.Range(0,hyperlative_adjectives.Length)];
		}

		//Show or not the hyperlative part of the name
		if(hyperlative_adjectives.Length > 0 && Random.value > 0.5)
		{
			random_scoring = scoring_system_hints[Random.Range(0,scoring_system_hints.Length)];
			
		}
		else
		{
			random_scoring = strange_words_list[Random.Range(0,strange_words_list.Length)];
		}

		//Show or not the fouls part of the name
		if(foul_hints.Length > 0 && Random.value > 0.5)
		{
			random_foul = foul_hints[Random.Range(0,foul_hints.Length)];
			
		}
		else
		{
			random_foul = strange_words_list[Random.Range(0,strange_words_list.Length)];
		}

		//Show or not the round finisher part of the name
		if(round_finisher_hints.Length > 0 && Random.value > 0.5)
		{
			random_round_finisher = round_finisher_hints[Random.Range(0,round_finisher_hints.Length)];
			
		}
		else
		{
			random_round_finisher = strange_words_list[Random.Range(0,strange_words_list.Length)];
		}


		//Show or not the last word of the name
		if(hyperlative_adjectives.Length > 0 && Random.value > 0)
		{
			random_last_word = last_word_list[Random.Range(0,last_word_list.Length)];
			
		}

		string final_mix = "";

		string pre_final_mix = random_hyperlative+random_scoring+random_last_word; 


		if(pre_final_mix.Length > 1)
		{

			final_mix = pre_final_mix.Substring(0,1).ToUpper() + pre_final_mix.Substring(1,pre_final_mix.Length - 1);
		}

		return final_mix;
	}



}
