using Microsoft.AspNetCore.Mvc;

namespace Assignment_2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiController : Controller
    {
        [HttpPost("J1/Delivedroid")]
        public int Delivedroid([FromForm] int Collisions, [FromForm] int Deliveries)
        {
            int score = (Deliveries * 50) - (Collisions * 10);

            if (Deliveries > Collisions)
            {
                score = score + 500;
            }

            return score;
        }

        [HttpGet("J1/ConveyorBeltSushi")]
        public int ConveyorBeltSushi([FromQuery] int red, [FromQuery] int green, [FromQuery] int blue)
        {

            int totalCost = (red * 3) + (green * 4) + (blue * 5);

            return totalCost;
        }

        [HttpGet("J2/ChiliPeppers")]
        public int chilipeppers([FromQuery] String ingredients)
        {
            string[] peppers = ingredients.Split(',');
            int shu = 0;

            foreach(var pepper in peppers)
            {
                switch (pepper)
                {
                    case "Poblano":
                        shu += 1500;
                        break;
                    case "Mirasol":
                        shu += 6000;
                        break;
                    case "Serrano":
                        shu += 15500;
                        break;
                    case "Cayenne":
                        shu += 40000;
                        break;
                    case "Thai":
                        shu += 75000;
                        break;
                    case "Habanero":
                        shu += 125000;
                        break;
                    default:
                        break;
                }
            }
            return shu;
        }



        [HttpGet("J2/DusaAndYobis")]
        public int DusaAndYobis([FromQuery] int dusaSize, [FromQuery] string yobisLine)
        {
            string[] yobisList = yobisLine.Split(',');
            
            foreach (var yobis in yobisList)
            {
                int yobisSize = int.Parse(yobis);

                if (dusaSize > yobisSize)
                {
                    dusaSize += yobisSize;
                } else if (dusaSize <= yobisSize)
                {
                    return dusaSize;
                }
            }

            return dusaSize;
        }

        [HttpGet("J3/BronzeCount")]
        public string bronzeCount([FromQuery] int numberOfParticipants, [FromQuery] string scoresInput)
        {
            string[] scoresString = scoresInput.Split(',');
            int[] scores = new int[scoresString.Length];

            for (int i = 0; i < scoresString.Length; i++)
            {
                scores[i] = int.Parse(scoresString[i]);
            }

            Array.Sort(scores);
            Array.Reverse(scores);

            var uniqueScores = scores.Distinct().ToList();
            int thirdHighest = uniqueScores[2];


            int count = 0;
            foreach (var score in scores)
            {
                if (score == thirdHighest)
                {
                    count++;
                }
            }


            return thirdHighest.ToString() + " " + count.ToString();
        }

    }
}
