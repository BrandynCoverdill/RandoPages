namespace RandoPages.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFlashCardToDb1 : DbMigration
    {
        public override void Up()
        {
            
            Sql("INSERT INTO FlashCards(CardType, Question, Answer) " +
                "VALUES('Computer Science', 'How many bits are in 1 byte?', '8 bits.')");
            Sql("INSERT INTO FlashCards(CardType, Question, Answer) " +
                "VALUES('Computer Science', 'What is 1NF?', '1NF is when each attribute contains only atomic values, and the value of each attribute contains only a single value from that domain.')");
            Sql("INSERT INTO FlashCards(CardType, Question, Answer) " +
                "VALUES('Art', 'What colors makes purple?', 'Red and Blue.')");
            Sql("INSERT INTO FlashCards(CardType, Question, Answer) " +
                "VALUES('Computer Science', 'Remote users can connect to an organizations network through this type of secure private connection.', 'VPN')");
            Sql("INSERT INTO FlashCards(CardType, Question, Answer) " +
                "VALUES('Computer Science', 'What is a Tenary Operator?', 'A tenary operator is an operator that takes three operands, which provides a way to shorten a simple if-else block.')");
        }
        
        public override void Down()
        {
        }
    }
}
