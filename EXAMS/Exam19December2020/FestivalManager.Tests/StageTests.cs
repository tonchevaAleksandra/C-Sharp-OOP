// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using FestivalManager.Entities;
    using NUnit.Framework;
    using System;

    [TestFixture]
	public class StageTests
    {
		private Stage stage;
		private Performer performer;

		[SetUp]
		public void SetUp()
        {
			this.performer = new Performer("Sean", "Paul", 40);
        }
		[Test]
	    public void ConstructorShouldWorkCorrectly()
	    {
			this.stage = new Stage();

			Assert.IsEmpty(this.stage.Performers);
			
		}
		[Test]
		public void AddPerformerShouldThrowExceptionWhenNull()
        {
			this.stage = new Stage();
			Assert.Throws<ArgumentNullException>(() =>
			{
				this.stage.AddPerformer(null);
			});
        }

	}
}