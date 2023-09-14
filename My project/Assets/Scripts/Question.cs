using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Question", menuName = "Question")]
public class Question : ScriptableObject
{
	[SerializeField] public string book;
	[SerializeField] int difficulty;
	[SerializeField] string query;
	[SerializeField] string[] alternatives;
	[SerializeField] string rightAnswer;
	[SerializeField] string bibleChapter;
	
	public string Book()
	{
		return book;
	}
	public int Difficulty()
	{
		return difficulty;
	}
	public string Query()
	{
		return query;
	}
	public string[] Alternatives()
	{
		return alternatives;
	}
	public string RightAnswer()
	{
		return rightAnswer;
	}
	public string BibleChapter()
	{
		return bibleChapter;
	}
}
