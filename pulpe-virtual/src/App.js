import React, { useEffect, useState, createContext, useContext } from "react";
import styled from "styled-components";
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";

import { Header } from "./components/Header";
import { Categories } from "./components/Categories";
import { Products } from "./components/Products";
import { TextField } from "@fluentui/react";

const pulpeVirtualContext = createContext();

const AppStyled = styled.div`
  height: 100vh;
  width: 100%;

  display: flex;
  justify-content: center;
`;

const Main = styled.div`
  width: 60%;

  @media screen and (max-width: 1024px) {
    width: 100%;
  }
`;

const Body = styled.div`
  display: flex;

  @media screen and (max-width: 1024px) {
    display: flex;
    flex-direction: column;
    width: 100%;
  }
`;

const SummaryProducts = styled.div`
  position: fixed;
  right: 0;
  bottom: 0;
  left: 0;
  height: 3rem;
  background: #217346;
  color: #ffffff;

  display: flex;
  flex-direction: row;
  align-items: center;
  direction: rtl;

  padding-right: 1rem;
  padding-left: 1rem;

  .Summary {
    box-shadow: 0px 0px 2px 0px #fff;
    padding: 0.5rem;
    font-weight: 700;
  }
`;

const MainComponent = () => {
  const [categories, setCategories] = useState([]);
  const [selectedCategory, setSelectedCategory] = useState(null);
  const [selectedProducts, setSelectedProducts] = useState([]);

  const context = useContext(pulpeVirtualContext);

  useEffect(() => {
    const fetchCategoriesAsync = async () => {
      const response = await fetch("http://localhost:5000/category")
        .then((response) => response.json())
        .then((response) => response);

      if (response.length) {
        setCategories(response);
      }
    };

    fetchCategoriesAsync();
  }, []);

  const handleSelectedCategory = (category) => {
    setSelectedCategory(category);
  };

  const handleSetStore = () =>
    context.setStore({ ...context.store, selectedProducts });

  return (
    <Main>
      <Header />

      <Body>
        <Categories
          categories={categories}
          onSelectedItem={handleSelectedCategory}
        />

        <Products
          products={selectedCategory ? selectedCategory.products : []}
          setSelectedProducts={setSelectedProducts}
        />
      </Body>

      {selectedProducts.length > 0 && (
        <SummaryProducts>
          <Link to="/checkout">
            <div
              className="Summary"
              onClick={handleSetStore}
            >{`Total: ${selectedProducts
              .map((product) => product.price)
              .reduce(
                (accumulator, currentValue) => accumulator + currentValue
              )} HNL`}</div>
          </Link>

          {selectedProducts.map((product, index) => (
            <div>{product.description}</div>
          ))}
        </SummaryProducts>
      )}
    </Main>
  );
};

const CheckoutComponent = () => {
  const [products, setProducts] = useState([]);

  const context = useContext(pulpeVirtualContext);

  useEffect(() => {
    setProducts(context.store.selectedProducts || []);
  }, [context.store]);

  const handleChange = (product) => (event, newValue) => {
    const newProducts = products.map((productItem) =>
      productItem.description === product.description
        ? { ...productItem, total: productItem.price * newValue }
        : productItem
    );

    setProducts(newProducts);
  };

  return (
    <Main>
      <Header />

      <div style={{ width: "100%", paddingTop: 10 }}>
        {products.map((product, index) => (
          <div
            key={index}
            style={{
              display: "grid",
              gridTemplateColumns: "350px 80px 60px 80px",
            }}
          >
            <strong>{product.description}</strong>
            <strong>{product.price}</strong>
            <TextField type="Number" onChange={handleChange(product)} />
            <strong style={{ marginLeft: 10 }}>{product.total}</strong>
          </div>
        ))}
      </div>
    </Main>
  );
};

const App = () => {
  const [store, setStore] = useState();

  return (
    <pulpeVirtualContext.Provider value={{ store, setStore }}>
      <AppStyled>
        <Router>
          <Switch>
            <Route exact path="/" component={MainComponent} />
            <Route exact path="/checkout" component={CheckoutComponent} />
          </Switch>
        </Router>
      </AppStyled>
    </pulpeVirtualContext.Provider>
  );
};

export default App;
