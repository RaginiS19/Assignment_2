using Microsoft.AspNetCore.Mvc;

namespace Assignment_2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiController : Controller
    {
        // POST: api/J1/Delivedroid
        // Calculates the score based on Collisions and Deliveries
        [HttpPost("J1/Delivedroid")]
        public int Delivedroid([FromForm] int Collisions, [FromForm] int Deliveries)
        {
            // Calculate initial score as (Deliveries * 50) - (Collisions * 10)
            int score = (Deliveries * 50) - (Collisions * 10);

            // Add 500 to score if Deliveries is greater than Collisions
            if (Deliveries > Collisions)
            {
                score = score + 500;
            }

            // Return the calculated score
            return score;
        }

        // GET: api/J1/ConveyorBeltSushi
        // Calculates the total cost based on the number of red, green, and blue sushi
        [HttpGet("J1/ConveyorBeltSushi")]
        public int ConveyorBeltSushi([FromQuery] int red, [FromQuery] int green, [FromQuery] int blue)
        {
            // Calculate total cost by multiplying each color's quantity by its respective cost
            int totalCost = (red * 3) + (green * 4) + (blue * 5);

            // Return the total cost
            return totalCost;
        }

        // GET: api/J2/ChiliPeppers
        // Returns the total SHU (Scoville Heat Unit) for a list of chili peppers
        [HttpGet("J2/ChiliPeppers")]
        public int chilipeppers([FromQuery] string ingredients)
        {
            // Split the ingredients string into individual pepper names
            string[] peppers = ingredients.Split(',');
            int shu = 0;

            // Iterate over each pepper and add its SHU value to the total
            foreach (var pepper in peppers)
            {
                // Switch statement to handle different pepper types
                switch (pepper)
                {
                    case "Poblano":
                        shu += 1500;  // Poblano SHU value
                        break;
                    case "Mirasol":
                        shu += 6000;  // Mirasol SHU value
                        break;
                    case "Serrano":
                        shu += 15500; // Serrano SHU value
                        break;
                    case "Cayenne":
                        shu += 40000; // Cayenne SHU value
                        break;
                    case "Thai":
                        shu += 75000; // Thai SHU value
                        break;
                    case "Habanero":
                        shu += 125000; // Habanero SHU value
                        break;
                    default:
                        break; // No action for unlisted peppers
                }
            }

            // Return the total SHU value
            return shu;
        }

        // GET: api/J2/DusaAndYobis
        // Determines the final Dusa size after processing the Yobis
        [HttpGet("J2/DusaAndYobis")]
        public int DusaAndYobis([FromQuery] int dusaSize, [FromQuery] string yobisLine)
        {
            // Split the yobisLine into a list of Yobis sizes
            string[] yobisList = yobisLine.Split(',');

            // Iterate over the Yobis list
            foreach (var yobis in yobisList)
            {
                // Parse each Yobis size from string to integer
                int yobisSize = int.Parse(yobis);

                // If the Dusa size is greater than the Yobis size, add the Yobis size to Dusa size
                if (dusaSize > yobisSize)
                {
                    dusaSize += yobisSize;
                }
                // If Dusa size is less than or equal to the Yobis size, return the current Dusa size
                else if (dusaSize <= yobisSize)
                {
                    return dusaSize;
                }
            }

            // Return the final Dusa size after processing all Yobis
            return dusaSize;
        }

        // GET: api/J3/BronzeCount
        // Calculates the third highest score and how many times it appears in the list
        [HttpGet("J3/BronzeCount")]
        public string bronzeCount([FromQuery] int numberOfParticipants, [FromQuery] string scoresInput)
        {
            // Split the scoresInput into an array of string scores
            string[] scoresString = scoresInput.Split(',');
            int[] scores = new int[scoresString.Length];

            // Convert string scores to integers
            for (int i = 0; i < scoresString.Length; i++)
            {
                scores[i] = int.Parse(scoresString[i]);
            }

            // Sort the scores in descending order
            Array.Sort(scores);
            Array.Reverse(scores);

            // Get the unique scores and identify the third highest
            var uniqueScores = scores.Distinct().ToList();
            int thirdHighest = uniqueScores[2];

            // Count how many times the third highest score appears in the list
            int count = 0;
            foreach (var score in scores)
            {
                if (score == thirdHighest)
                {
                    count++;
                }
            }

            // Return the third highest score and its count
            return thirdHighest.ToString() + " " + count.ToString();
        }
    }
}
