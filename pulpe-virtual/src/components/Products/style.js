import styled from "styled-components";

export const ProductContainer = styled.div`
  padding-left: 1rem;
  width: 100%;

  .Product {
    cursor: pointer;
    padding: 1rem;
    border-radius: 1rem;

    display: flex;
    flex-direction: row;

    .Container-Img {
      position: relative;

      .Add {
        display: none;
        align-items: center;
        justify-content: center;

        position: absolute;
        bottom: 0;
        right: 0;

        height: 40px;
        width: 40px;
        border-radius: 50%;
        background: green;

        i {
          font-size: 1rem;
          color: #ffffff;
          font-weight: 700;
        }
      }

      :hover {
        .Add {
          display: flex;
        }
      }

      > img {
        width: 10rem;
        height: 10rem;
      }
    }

    .Description {
      display: flex;
      flex-direction: column;
    }

    :hover {
      box-shadow: 0px 0px 5px 0px rgba(0, 0, 0, 0.3);

      strong {
        color: #d83b01;
      }
    }
  }
`;
