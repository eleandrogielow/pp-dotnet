using System;
using System.Collections.Generic;

namespace Dio.Series.interfaces
{
    public interface IRepositorio<T>
    {
        List<T> Lista();
        T RetornarPorId(int id);
        void Insere(T entidade);
        void Exclui(int id);
        void Atualizar(int id, T entidade);
        int ProximoId();
    }
}