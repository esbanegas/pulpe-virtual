import React from "react";
import { Icon } from "@fluentui/react";
import { ProductContainer } from "./style";

export const Products = ({ products, setSelectedProducts }) => {
  const handleAddClick = (product) => () => {
    setSelectedProducts((selectedProducts) => [
      ...selectedProducts,
      { ...product },
    ]);
  };

  const onRenderImg = (product) => require(`${product.pathImg}`);

  return (
    <ProductContainer>
      <h3>Productos</h3>

      {products.map((product, index) => (
        <div className="Product" key={index}>
          <div className="Container-Img">
            <img src={onRenderImg(product)} />
            <div className="Add" onClick={handleAddClick(product)}>
              <Icon iconName="Add" />
            </div>
          </div>

          <div className="Description">
            <strong>{product.description}</strong>
            <span>{product.category}</span>
            <h3>{`${product.coin} ${product.price}`}</h3>
          </div>
        </div>
      ))}
    </ProductContainer>
  );
};
