using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LXTouch.Components
{
    public partial class LXEditor
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Inject]
        public LXLayoutService Layout { get; set; }

        [Inject]
        public ILocalStorageService LocalStorage { get; set; }


        #region Selection

        private LXLayoutElement selectedElement = null;

        public event EventHandler SelectedElementChanged;

        public LXLayoutElement SelectedElement 
        {
            get { return selectedElement; } 
            set
            {
                if(selectedElement != value)
                {
                    selectedElement = value;
                    if (SelectedElementChanged != null)
                        SelectedElementChanged(this, EventArgs.Empty);
                }
            }
        }

        public void Select(LXLayoutElement element)
        {
            SelectedElement = element;
        }

        public void Remove(LXLayoutElement element)
        {
            Layout.CurrentLayout.RemoveElement(element);
        }

        #endregion


        #region Drag and Drop

        public LXLayoutElement DragElement { get; set; }

        public double DragOffsetX { get; set; }

        public double DragOffsetY { get; set; }

        public void StartDrag(DragEventArgs e, LXLayoutElement element)
        {
            DragElement = element;

            //Make a note of the offset into the control so we can correct the drag position on drop.
            DragOffsetX = e.OffsetX;
            DragOffsetY = e.OffsetY;
        }

        public void EndDrag(DragEventArgs e)
        {
            if (DragElement != null)
            {
                if(!Layout.CurrentLayout.Elements.Contains(DragElement))
                {
                    Layout.CurrentLayout.AddElement(DragElement);
                }

                double positionX = e.OffsetX - DragOffsetX;
                double positionY = e.OffsetY - DragOffsetY;

                Console.WriteLine($"X: {positionX}, Y: {positionY}");

                if(Layout.CurrentLayout.SnapToGrid)
                {
                    var gridSize = Layout.CurrentLayout.GridSize;
                    positionX = Math.Round(positionX / gridSize) * gridSize;
                    positionY = Math.Round(positionY / gridSize) * gridSize;
                }

                DragElement.PositionX = positionX;
                DragElement.PositionY = positionY;
            }
            StateHasChanged();
        }

        #endregion
    }
}
