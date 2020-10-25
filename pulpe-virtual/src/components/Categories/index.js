import React from "react";
import styled from "styled-components";

const CategoryContainer = styled.div`
  .Categories {
    .Category {
      width: 20rem;
      cursor: pointer;
      padding-bottom: 0.6rem;

      :hover {
        color: #d83b01;
      }
    }
  }

  @media screen and (max-width: 1024px) {
    h3 {
      display: none;
    }

    .Categories {
      display: flex;
      flex-direction: row;
      flex-wrap: nowrap;
      width: 100%;
      height: 2rem;
      overflow-x: auto;
      overflow-y: hidden;

      .Category {
        width: 1000px;
        cursor: pointer;
        margin-left: 5px;

        :hover {
          color: #d83b01;
        }
      }
    }
  }
`;

export const Categories = ({ categories, onSelectedItem }) => {
  const handleSelectedItem = (category) => () => {
    if (onSelectedItem) {
      onSelectedItem(category);
    }
  };

  return (
    <CategoryContainer>
      <h3>Categorias</h3>

      <div className="Categories">
        {categories.map((category, index) => (
          <div
            key={index}
            className="Category"
            onClick={handleSelectedItem(category)}
          >
            {category.description}
          </div>
        ))}
      </div>
    </CategoryContainer>
  );
};
