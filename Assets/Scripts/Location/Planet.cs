using System.Collections.Generic;
using Objects;
using UnityEngine;

namespace Location
{
    public class Planet
    {
        private List<EnvironmentElement> _environmentElements = new List<EnvironmentElement>();
        public List<EnvironmentElement> environmentElements => _environmentElements;

        public void FillEnvironmentElements(List<EnvironmentElement> elements)
        {
            _environmentElements = elements;
        }
        
        public void AddEnvironmentElement(EnvironmentElement element)
        {
            _environmentElements.Add(element);
        }

        public void Remove(EnvironmentElement element)
        {
            _environmentElements.Remove(element);
        }

        public void ClearEnvironmentElementsList()
        {
            _environmentElements.Clear();
        }
    }
}
