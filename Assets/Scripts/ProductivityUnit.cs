using UnityEngine;

public class ProductivityUnit : Unit
{

    private ResourcePile m_CurrentPile = null;
    public float ProductivityMultiplier = 2f;
    protected override void BuildingInRange()
    {
        if (m_CurrentPile == null)
        {
            ResourcePile pile = m_Target as ResourcePile;

            if (pile != null)
            {
                m_CurrentPile = pile;
                m_CurrentPile.ProductionSpeed *=  ProductivityMultiplier;
            }
        }
        // end of new code
    }

    public override void GoTo(Building target)
    {
        ResetProductivity();    
        base.GoTo(target);
    }


    public override void GoTo(Vector3 position)
    {
        ResetProductivity();
        base.GoTo(position);
    }

    private void ResetProductivity()
    {
        if (m_CurrentPile != null)
        {
            m_CurrentPile.ProductionSpeed /= ProductivityMultiplier;
            m_CurrentPile = null;
        }
    }
}