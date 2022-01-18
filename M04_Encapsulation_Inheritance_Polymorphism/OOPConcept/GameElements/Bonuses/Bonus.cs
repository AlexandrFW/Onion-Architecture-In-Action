namespace OOPConcept.GameElements.Bonuses
{
	public abstract class Bonus
	{
		private int _score;

		public Bonus(int score)
		{
			_score = score;
		}

		public int Score
		{
			get
			{
				return _score;
			}
		}
	}
}