using Microsoft.ML.Probabilistic.Distributions;
using Microsoft.ML.Probabilistic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClueBot
{
    public class ClueBase
    {
        public InferenceEngine ie;
        public VariableArray2D<Double> cptCards;
        public VariableArray2D<Bernoulli> cardMatrix;
        public VariableArray2D<Boolean> cardEstimate;
        public Variable<int> numberOfPlayers;
        public Range playersRange;
        public Range numberOfCards;

        public Variable<int> numberOfPeople;
        public Variable<int> numberOfWeapons;
        public Variable<int> numberOfRooms;

        public VariableArray<int> playerHandsize;


        // needs to be redone with dirichlet random variable 

        public void SetClueSettings(int NumOfPlayers, int NumOfPeople, int NumOfWeapons, int NumOfRooms, int[] PlayersHandSize)
        {
            numberOfPlayers = NumOfPlayers;
            playersRange = new Range(numberOfPlayers+1);
            numberOfPeople = NumOfPeople;
            numberOfWeapons = NumOfWeapons;
            numberOfRooms = NumOfRooms;
            numberOfCards = new Range(numberOfPeople + numberOfWeapons + numberOfRooms);

            playerHandsize = Variable.Array<int>(playersRange);
            for(int i =0; i< PlayersHandSize.Length; i++)
            {
                playerHandsize[i] = PlayersHandSize[i];
            }
            cptCards = Variable.Array<double>(numberOfCards, playersRange);
            cardMatrix = Variable.Array<Bernoulli>(numberOfCards, playersRange);


        }


        //passes the form of vectors 



        public void CreateModel()
        {

            if (ie == null)
            {
                ie = new InferenceEngine();
            }



            
        }


        public void updateIndividCard(Variable<int> cardNumber, Variable<int> playerNumber)
        {
            cardEstimate[cardNumber, playerNumber].ObservedValue = true;
        } 


        public void updateHand(int[] cardNumbers)
        {
            foreach(int i in cardNumbers)
            {
                updateIndividCard(i, 1);

            }
        }


      //  public void generateUniformCardProbabilities(double uniformValue)
       // {
         //   using (Variable.ForEach(playersRange))
           // {
             //   using (Variable.ForEach(numberOfCards))
               // {
                 //   cptCards[numberOfCards, playersRange] = uniformValue;
               // }
           // }
        //}


        // needs work
       // public void generateRandom()
        //{
        //    using (Variable.ForEach(numberOfCards))
          //  {
            //    using (Variable.ForEach(playersRange))
              //  {
               //     cptCards[numberOfCards, playersRange] = Variable.DirichletUniform(playersRange.SizeAsInt)[playersRange];
               // }
                     
           // }
        //}




    }
}
