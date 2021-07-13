// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

import * as React from 'react';
import { RouteComponentProps } from 'react-router-dom';
import { withTranslation, WithTranslation } from "react-i18next";
import { Button, Dropdown, Flex } from '@fluentui/react-northstar'
import './newMessage.scss';
import './teamTheme.scss';
import { TFunction } from "i18next";



type dropdownItem = {
    key: string,
    header: string,
    content: string,
    image: string,
    team: {
        id: string,
    },
}



export interface IState {
    dropDownInput?:any;
    selectedValue?:any
}

export interface IProps extends WithTranslation {
    history?:any
}

class InitialPageNewMessage extends React.Component<IProps, IState> {
    readonly localize: TFunction;

    constructor(props: IProps) {
        super(props);
        this.localize = this.props.t;
        
        this.state = {
            dropDownInput:[this.localize("ImageUpload"),this.localize("PDFUpload"),this.localize("EmailUpload"),this.localize("Q&AUpload")]
        }
        
    }

    public async componentDidMount() {
        this.setState({
            selectedValue:this.state.dropDownInput[0]
        })
    }

    private handleOnchange = (data: any) => {
        this.setState({
            selectedValue: data
        })
    }

    private onNext=()=>{
        this.props.history.push({ pathname: "/newmessage", state: { data: this.state.selectedValue} })
    }

    public render(): JSX.Element {
        return(
            <div style={{margin:"20px"}}>
            <Dropdown fluid
                           items={this.state.dropDownInput}
                           search={false}
                           placeholder={this.state.dropDownInput[0]}
                           className="dropdown_style"
                           onChange={(event, { value }) => this.handleOnchange(value)}
                       />
                       <Flex className="footerContainer" vAlign="end" hAlign="end">
                                <Flex className="buttonContainer" styles={{position:"absolute",bottom:"20px"}}>
                                    <Button content={this.localize("Next")} id="saveBtn" onClick={()=>this.onNext()} primary />
                                </Flex>
                            </Flex>
        </div>

        )
    }




}

const newMessageWithTranslation = withTranslation()(InitialPageNewMessage);
export default newMessageWithTranslation;
