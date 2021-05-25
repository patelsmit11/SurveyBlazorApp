using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;

namespace SurveyBlazorApp.Shared
{
    public partial class CheckBoxList<TItem>
    {
        //Data for the Checkbox   
        [Parameter] public IEnumerable<TItem> Data { get; set; }
        // The field to be shown adjacent to checkbox  
        [Parameter] public Func<TItem, string> TextField { get; set; }
        // The Value which checkbox will return when checked   
        [Parameter] public Func<TItem, object> ValueField { get; set; }
        // CSS Style for the Checkbox container   
        [Parameter] public string Style { get; set; }
        // Any childd content for the control (if needed)  
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public EventCallback<string> ValueChanged { get; set; }

        // The array which contains the list of selected checkboxs   
        public List<string> SelectedValues { get; set; } = new();

        //Method to update the selected value on click on checkbox   
        public void CheckboxClicked(string aSelectedId, object aChecked)
        {
            if ((bool)aChecked)
            {
                if (!SelectedValues.Contains(aSelectedId))
                {
                    SelectedValues.Add(aSelectedId);
                }
            }
            else
            {
                if (SelectedValues.Contains(aSelectedId))
                {
                    SelectedValues.Remove(aSelectedId);
                }
            }

            ValueChanged.InvokeAsync(string.Join(",", SelectedValues));
            StateHasChanged();
        }
    }
}
