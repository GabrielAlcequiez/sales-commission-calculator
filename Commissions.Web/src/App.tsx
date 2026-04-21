import { Header } from './components/Layout/Header';
import { Footer } from './components/Layout/Footer';
import { Calculator } from './components/Calculator/Calculator';

function App() {
  return (
    <div className="app">
      <Header />
      <main className="main-content">
        <Calculator />
      </main>
      <Footer />
    </div>
  );
}

export default App;
