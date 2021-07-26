using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ViewModels.Library
{
    public class Paginador<T> // se coloca la t para que sea generica y reciba cualquier tipo de clase
    {
        private List<T> _dataList;
        private Label _label;
        private static int maxReg, _reg_por_pagina, pageCount, numPagi = 1;

        public Paginador(List<T> dataList, Label label, int reg_por_pagina)
        {
            _dataList = dataList;
            _label = label;
            _reg_por_pagina = reg_por_pagina;
            cargarDatos();
        }
        private void cargarDatos() //#22YT
        {
            numPagi = 1;
            maxReg = _dataList.Count;
            pageCount = (maxReg / _reg_por_pagina);
            ////Ajuste el número de la página si la última página contiene una parte de la página.
            if ((maxReg % _reg_por_pagina) > 0)
            {
                pageCount += 1;
            }
            _label.Text = $"Paginas 1/ { pageCount}"; //Muestra si tenemos el datagriewiev completo y muestra que hay mas paginas en el paginador
        }
        public int primero() // procedimiento para navegar en primera pagina
        {
            numPagi = 1;
            _label.Text = $"Paginas { numPagi}/{pageCount}";
            return numPagi;
        }
        public int anterior() // procedimiento para navegar en pagina anterior
        {
            if (numPagi > 1)
            {
                numPagi -= 1;
                _label.Text = $"Paginas { numPagi}/{pageCount}";
            }
            return numPagi;
        }
        public int siguiente() // procedimiento para navegar en pagina siguiente 
        {
            if (numPagi == pageCount)
                numPagi -= 1;
            if (numPagi < pageCount)
            {
                numPagi += 1;
                _label.Text = $"Paginas { numPagi}/{pageCount}";
            }
            return numPagi;
        }
        public int ultimo() // metodo para pasar a la ultima pagina
        {
            numPagi = pageCount;
            _label.Text = $"Paginas { numPagi}/{pageCount}";
            return numPagi;
        }


    }
}
