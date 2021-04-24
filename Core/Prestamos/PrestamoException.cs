using System;

namespace DIA_BANCO_V1 {
    public class PrestamoException : Exception {
        public PrestamoException() {
        }

        public PrestamoException(string message)
            : base(message) {
        }

        public PrestamoException(string message, Exception inner)
            : base(message, inner) {
        }
    }
}