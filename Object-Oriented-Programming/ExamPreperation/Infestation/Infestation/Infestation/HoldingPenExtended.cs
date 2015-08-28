namespace Infestation
{
    using System;

    public class HoldingPenExtended : HoldingPen
    {
        protected override void ExecuteAddSupplementCommand(string[] commandWords)
        {
            var unit = this.GetUnit(commandWords[2]);
            ISupplement supplement;

            switch (commandWords[1])
            {
                case "Weapon":
                    supplement = new Weapon();
                    break;
                case "PowerCatalyst":
                    supplement = new PowerCatalyst();
                    break;
                case "HealthCatalyst":
                    supplement = new HealthCatalyst();
                    break;
                case "AggressionCatalyst":
                    supplement = new AggressionCatalyst();
                    break;
                default:
                    throw new ArgumentException("Unsupported command", commandWords[1]);
            }

            unit.AddSupplement(supplement);
        }

        protected override void ExecuteInsertUnitCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "Marine":
                    var marine = new Marine(commandWords[2]);
                    this.InsertUnit(marine);
                    break;
                case "Tank":
                    var tank = new Tank(commandWords[2]);
                    this.InsertUnit(tank);
                    break;
                case "Parasite":
                    var parasite = new Parasite(commandWords[2]);
                    this.InsertUnit(parasite);
                    break;
                case "Queen":
                    var queen = new Queen(commandWords[2]);
                    this.InsertUnit(queen);
                    break;
                default:
                    base.ExecuteInsertUnitCommand(commandWords);
                    break;
            }
        }

        protected override void ProcessSingleInteraction(Interaction interaction)
        {
            switch (interaction.InteractionType)
            {
                case InteractionType.Infest:
                    var targetUnit = this.GetUnit(interaction.TargetUnit);
                    var targetUnitClassification = InfestationRequirements.RequiredClassificationToInfest(targetUnit.UnitClassification);
                    
                    if (interaction.SourceUnit.UnitClassification == UnitClassification.Biological &&
                        targetUnitClassification == UnitClassification.Biological)
                    {
                        targetUnit.AddSupplement(new InfestationSpores());    
                    }
                    else if (interaction.SourceUnit.UnitClassification == UnitClassification.Mechanical &&
                        targetUnitClassification == UnitClassification.Psionic)
                    {
                        targetUnit.AddSupplement(new InfestationSpores());   
                    }
                    else if (interaction.SourceUnit.UnitClassification == UnitClassification.Psionic &&
                        targetUnitClassification == UnitClassification.Psionic)
                    {
                        targetUnit.AddSupplement(new InfestationSpores());   
                    }
                    
                    break;
                default:
                    base.ProcessSingleInteraction(interaction);
                    break;
            }
        }
    }
}
