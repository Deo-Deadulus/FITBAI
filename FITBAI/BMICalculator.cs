using System;

namespace FITBAI
{
    public static class BMICalculator
    {
        // Enum to strictly define the categories
        public enum BMICategory
        {
            Underweight,
            Normal,
            Overweight,
            Obese
        }

        /// <summary>
        /// Calculates BMI. Formula: weight (kg) / [height (m)]^2. Returns value to 1 decimal.
        /// </summary>
        public static double CalcBMI(double heightCm, double weightKg)
        {
            if (heightCm <= 0) return 0; // Prevent division by zero

            double heightM = heightCm / 100.0;
            double bmi = weightKg / (heightM * heightM);

            return Math.Round(bmi, 1);
        }

        /// <summary>
        /// Classifies the BMI value into the standard medical categories.
        /// </summary>
        public static BMICategory GetBMICategory(double bmi)
        {
            if (bmi < 18.5) return BMICategory.Underweight;
            if (bmi <= 24.9) return BMICategory.Normal;
            if (bmi <= 29.9) return BMICategory.Overweight;

            return BMICategory.Obese;
        }

        /// <summary>
        /// The Smart Algorithm Matrix: Checks if a specific goal is allowed 
        /// based on the user's current BMI category.
        /// </summary>
        public static bool IsGoalAllowed(string goalName, BMICategory category)
        {
            switch (goalName)
            {
                case "Lose Weight":
                    // Normal, Overweight, Obese
                    return category != BMICategory.Underweight;

                case "Maintain Weight":
                    // Normal only
                    return category == BMICategory.Normal;

                case "Gain Weight":
                    // Underweight, Normal
                    return category == BMICategory.Underweight || category == BMICategory.Normal;

                case "Gain Muscle":
                case "Increase Stamina":
                    // Underweight, Normal, Overweight (Restricted for Obese)
                    return category != BMICategory.Obese;

                case "Flexibility":
                    // All categories
                    return true;

                default:
                    return false;
            }
        }
    }
}